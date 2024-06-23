using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	public PlayerStorage player;
	public TMP_Text cash_text;
	public DaySystem daySystem;
	public QuotaSystem quotaSystem;
	public TMP_Text quota_text;
	public NPCPool CustomerPool;
	public List<Product> ProductUnlocked = new List<Product>();
	public List<Sprite> CustomerSprites = new List<Sprite>();
	protected override void OnAwake()
	{
		player = ScriptableObject.Instantiate(player);
		player.currency_text = cash_text;
		player.UpdateCurrencyText();

		quotaSystem.quota_text = quota_text;
		quotaSystem.UpdateQuotaText();
	}

}
