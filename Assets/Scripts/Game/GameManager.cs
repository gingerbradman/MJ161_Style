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
	public NPCPool VendorPool;
	public List<Product> ProductUnlocked = new List<Product>();
	public List<Sprite> CustomerSprites = new List<Sprite>();

	public List<SpriteRenderer> materialsSprites;
	public List<SpriteRenderer> productsSprites;

	protected override void OnAwake()
	{
		player = ScriptableObject.Instantiate(player);
		player.currency_text = cash_text;
		player.UpdateCurrencyText();

		quotaSystem.quota_text = quota_text;
		quotaSystem.UpdateQuotaText();
	}

	public void UpdateInventory()
	{
		UpdateMaterialsInventory();
		UpdateProductsInventory();
	}

	public void UpdateMaterialsInventory()
	{
		for(int i = 0; i<=player.materials.Count; i++)
		{
			materialsSprites[i].sprite = player.materials[i].Icon;
		}
	}

	public void UpdateProductsInventory()
	{
		for(int i = 0; i<=player.products.Count; i++)
		{
			productsSprites[i].sprite = player.products[i].Icon;
		}
	}

}
