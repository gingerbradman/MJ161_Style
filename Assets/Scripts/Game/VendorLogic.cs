using UnityEngine.UI;
using UnityEngine;

public class VendorLogic : RenderedObject, IPooled, NPCLogic
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

	public override void Awake()
	{
		base.Awake();
		WaitTimer.OnTimerEnded += OnPatientRanOut;
		DecorateVendor();
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
	}

	public void DecorateVendor()
	{
		if (GameManager.Instance.CustomerSprites.Count > 0) renderObject.GetComponent<Image>().sprite = GameManager.Instance.VendorSprites[Random.Range(0,GameManager.Instance.VendorSprites.Count)];
		//if (GameManager.Instance.ProductUnlocked.Count > 0) productWanted = GameManager.Instance.ProductUnlocked[Random.Range(0, GameManager.Instance.ProductUnlocked.Count)];
		//WantedRender.sprite = productWanted.Icon;
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
	}

	void OnPatientRanOut()
	{
		WantedRender.gameObject.SetActive(false);
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}

	public void DeliverProduct()
	{
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}
}
