using UnityEngine.UI;
using UnityEngine;
using UnityEditor.UI;

public class VendorLogic : RenderedObject, IPooled, NPCLogic
{
	public ItemMaterial sellingMaterial;
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
		sellingMaterial = null;
		renderObject.GetComponent<Image>().sprite = null;
		WantedRender.sprite = null;
		WantedRender.gameObject.SetActive(false);
	}

	public void DecorateVendor()
	{
		if (GameManager.Instance.CustomerSprites.Count > 0) renderObject.GetComponent<Image>().sprite = GameManager.Instance.VendorSprites[Random.Range(0,GameManager.Instance.VendorSprites.Count)];
		if (GameManager.Instance.MaterialsSold.Count > 0) sellingMaterial = GameManager.Instance.MaterialsSold[Random.Range(0, GameManager.Instance.MaterialsSold.Count)];
		WantedRender.sprite = sellingMaterial.Icon;
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
		WantedRender.gameObject.SetActive(false);
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}

	public void OnClick()
	{
		if (GameManager.Instance.player.Append(sellingMaterial))
		{
			DeliverProduct();
		}

	}
}
