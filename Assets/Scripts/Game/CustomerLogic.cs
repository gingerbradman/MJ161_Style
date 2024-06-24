using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;

public class CustomerLogic : RenderedObject, IPooled, NPCLogic
{
	public Product productWanted;
	const float MINIMUM_PATIENT_TIME = 10;
	const float MAXIMUM_PATIENT_TIME = 30;
	public float PatientTime
	{
		get => Random.Range(MINIMUM_PATIENT_TIME, MAXIMUM_PATIENT_TIME);
	}
	public Image WantedRender;
	public Timer WaitTimer;
	public GameObject Popup;
	public bool Received;

	public override void Awake()
	{
		base.Awake();
		WaitTimer.OnTimerEnded += OnPatientRanOut;
		DecorateCustomer();
	}
	public void Reset()
	{
		transform.position = Vector3.zero;
		renderObject.transform.position = Vector3.zero;
		renderObject.transform.SetParent(this.transform);
		productWanted = null;
		renderObject.GetComponent<Image>().sprite = null;
		WantedRender.sprite = null;
		WantedRender.gameObject.SetActive(false);
		Received = false;
	}

	public void DecorateCustomer()
	{
		if (GameManager.Instance.CustomerSprites.Count > 0) renderObject.GetComponent<Image>().sprite = GameManager.Instance.CustomerSprites[Random.Range(0,GameManager.Instance.CustomerSprites.Count)];
		if (GameManager.Instance.ProductUnlocked.Count > 0) productWanted = GameManager.Instance.ProductUnlocked[Random.Range(0, GameManager.Instance.ProductUnlocked.Count)];
		WantedRender.sprite = productWanted.Icon;
	}

	public Timer GetTimer()
	{
		return WaitTimer;
	}

	public void StartWaiting()
	{
		WantedRender.gameObject.SetActive(true);
		WaitTimer.duration = PatientTime;
		WaitTimer.Begin();
		GameObject.Find("Audio").GetComponent<SFXManager>().PlayCustomer();
	}

	void OnPatientRanOut()
	{
		WantedRender.gameObject.SetActive(false);
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}

	public void DeliverProduct()
	{
		WantedRender.gameObject.SetActive(false);
		Received = true;
		WaitTimer.Stop();
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}

	public void OnClick()
	{
		if (GameManager.Instance.player.Remove(productWanted))
		{
			DeliverProduct();
		}
	}
}
