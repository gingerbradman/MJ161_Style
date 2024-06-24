using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuotaSystem : MonoBehaviour
{
	public int CurrentQuota = 100;
	public TMP_Text quota_text;
	public event Action<bool> QuotaMet;
	void checkQuota()
	{
		GameManager.Instance.player.m_currency -= CurrentQuota;
		QuotaMet?.Invoke(GameManager.Instance.player.m_currency >= 0);
	} 

	public void UpdateQuota(int x)
	{
		CurrentQuota = x;
		UpdateQuotaText();
	}

	public void UpdateQuotaText()
	{
		quota_text.text = ""+CurrentQuota;
	}
}
