using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyReport : MonoBehaviour
{
	public TMPro.TMP_Text customer_served;
	string initial_text_customer_served;
	public TMPro.TMP_Text material_bought;
	string initial_text_material_bought;
	public TMPro.TMP_Text money_made;
	string initial_text_money_made;
	public TMPro.TMP_Text Quota;
	string initial_text_Quota;
	public DayReport report
	{
		set => SetReport(value);
	}

	void Awake()
	{
		initial_text_customer_served = customer_served.text;
		initial_text_material_bought = material_bought.text;
		initial_text_money_made = money_made.text;
		initial_text_Quota = Quota.text;
	}

	public void SetReport(DayReport value)
	{
		customer_served.text = initial_text_customer_served + value.customer_served.ToString();
		material_bought.text = initial_text_customer_served+value.material_bought.ToString();
		money_made.text = initial_text_money_made+value.money_made.ToString();
		if (GameManager.Instance.player.GetCurrency() >= GameManager.Instance.quotaSystem.CurrentQuota)
		{
			Quota.text = Quota.text + " met!";
		}
		else Quota.text = Quota.text + " failed!";
	}

	public void OnButtonPressed()
	{
		if (GameManager.Instance.player.GetCurrency() >= GameManager.Instance.quotaSystem.CurrentQuota)
		{
			GameManager.Instance.daySystem.StartDay();
			gameObject.SetActive(false);
		}
	}
}
