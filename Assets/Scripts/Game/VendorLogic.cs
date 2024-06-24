using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VendorLogic : RenderedObject, IPooled, NPCLogic
{
	public ItemMaterial sellingMaterial;
	const float MINIMUM_PATIENT_TIME = 0;
	const float MAXIMUM_PATIENT_TIME = 0;
	public float PatientTime
	{
		get => Random.Range(MINIMUM_PATIENT_TIME, MAXIMUM_PATIENT_TIME);
	}
	public Image WantedRender;
	public SpriteRenderer SpeechBubble;
	public TMP_Text cost_text;
	public Timer WaitTimer;
	public bool received;
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
		cost_text.text = "";
		cost_text.gameObject.SetActive(false);
		received = false;
	}

	public void DecorateVendor()
	{
		if (GameManager.Instance.CustomerSprites.Count > 0) renderObject.GetComponent<Image>().sprite = GameManager.Instance.VendorSprites[Random.Range(0,GameManager.Instance.VendorSprites.Count)];
		if (GameManager.Instance.MaterialsSold.Count > 0) sellingMaterial = GameManager.Instance.MaterialsSold[Random.Range(0, GameManager.Instance.MaterialsSold.Count)];
		WantedRender.sprite = sellingMaterial.Icon;
		cost_text.text = "$"+sellingMaterial.ExpectedValue;
		cost_text.gameObject.SetActive(false);
		renderObject.transform.SetParent(GameObject.FindGameObjectWithTag(Global.CANVAS_GROUP).transform);
	}

	public Timer GetTimer()
	{
		return WaitTimer;
	}
	public void StartWaiting()
	{
		WantedRender.gameObject.SetActive(true);
		cost_text.gameObject.SetActive(true);
		WaitTimer.duration = PatientTime;
		WaitTimer.Begin();
		GameObject.Find("Audio").GetComponent<SFXManager>().PlayVendor();
	}

	void OnPatientRanOut()
	{
		WantedRender.gameObject.SetActive(false);
		cost_text.gameObject.SetActive(false);
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}

	public void DeliverProduct()
	{
		GameManager.Instance.player.Append(sellingMaterial);
		received = true;
		WantedRender.gameObject.SetActive(false);
		cost_text.gameObject.SetActive(false);
		WaitTimer.Stop();
		CustomerQueue.CustomerFinished?.Invoke(gameObject);
	}

	public void OnClick()
	{
		if (GameManager.Instance.player.GetCurrency() >= sellingMaterial.ExpectedValue && GameManager.Instance.player.materials.Count < GameManager.Instance.player.maxInventory && !WaitTimer.isPaused)
		{
			DeliverProduct();
		}
	}
}
