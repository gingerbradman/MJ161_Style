using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu]
public class PlayerStorage : ScriptableObject
{
    public List<ItemMaterial> materials = new List<ItemMaterial>();
	public List<Product> products = new List<Product>();
	public int m_currency = 40;
	public TMP_Text currency_text;
	public List<SpriteRenderer> materialsSprites;
	public List<SpriteRenderer> productsSprites;


	public void Append(object what)
	{
		switch (what)
		{
			case ItemMaterial:
				materials.Add(what as ItemMaterial);
				break;
			case Product:
				products.Add(what as Product);
				break;
		}
	}

	public void Remove(object what)
	{
		switch (what)
		{
			case ItemMaterial:
				materials.Remove(what as ItemMaterial);
				break;
			case Product:
				products.Remove(what as Product);
				break;
		}
	}

	public void UpdateCurrency(int x)
	{
		m_currency += x;
		UpdateCurrencyText();
	}

	public void UpdateCurrencyText()
	{
		currency_text.text = ""+m_currency;
	}


}


