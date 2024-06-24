using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuotaSystem : MonoBehaviour
{
	public int CurrentQuota = 100;
	public TMP_Text quota_text;
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
