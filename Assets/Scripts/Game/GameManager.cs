using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Diagnostics;

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
	public List<ItemMaterial> MaterialsSold = new List<ItemMaterial>();
	public List<Sprite> CustomerSprites = new List<Sprite>();
	public List<SpriteRenderer> materialsSprites;
	public List<SpriteRenderer> productsSprites;
	public List<Sprite> VendorSprites = new List<Sprite>();
	public GameObject slotPrefab;
	protected override void OnAwake()
	{
		player = ScriptableObject.Instantiate(player);
		player.currency_text = cash_text;
		player.UpdateCurrencyText();
		UpdateInventory();

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
		for (int i = 0; i < materialsSprites.Count; i++)
		{
			Transform transform = materialsSprites[i].gameObject.transform;
			if(transform.childCount > 0){Destroy(transform.GetChild(0).gameObject);}
		}
		
		for (int i = 0; i < player.materials.Count; i++)
		{
			GameObject cloneSlot = Instantiate(slotPrefab, materialsSprites[i].gameObject.transform);
			cloneSlot.GetComponent<SpriteRenderer>().sprite = player.materials[i].Icon;
		}
	}

	public void UpdateProductsInventory()
	{
		for (int i = 0; i < productsSprites.Count; i++)
		{
			Transform transform = productsSprites[i].gameObject.transform;
			if(transform.childCount > 0){Destroy(transform.GetChild(0).gameObject);}
		}
		
		for (int i = 0; i < player.products.Count; i++)
		{
			GameObject cloneSlot = Instantiate(slotPrefab, productsSprites[i].gameObject.transform);
			cloneSlot.GetComponent<SpriteRenderer>().sprite = player.products[i].Icon;
		}
	}

}
