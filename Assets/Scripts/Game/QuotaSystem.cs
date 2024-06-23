using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuotaSystem : MonoBehaviour
{
	public int CurrentQuota;
	public event Action<bool> QuotaMet;
	void checkQuota()
	{
		GameManager.Instance.player.Currency -= CurrentQuota;
		QuotaMet?.Invoke(GameManager.Instance.player.Currency >= 0);
	} 
}
