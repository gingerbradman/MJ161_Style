using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD;

[CreateAssetMenu]
public class PlayerStorage : ScriptableObject
{
	public List<ItemMaterial> materials = new List<ItemMaterial>();
	public List<Product> products = new List<Product>();
	public int maxInventory = 13;
	public int m_currency = 40;
	public int GetCurrency() { return m_currency; }
	public TMP_Text currency_text;

	public bool Append(object what)
	{
		bool res = false;
		switch (what)
		{
			case ItemMaterial:
				int value = (what as ItemMaterial).ExpectedValue;
				if (value < GetCurrency() && materials.Count < maxInventory)
				{
					UpdateCurrency(GetCurrency() - value);
					materials.Add(what as ItemMaterial);
					res = true;
				}
				break;

			case Product:
				if (products.Count < maxInventory)
				{
					products.Add(what as Product);
					res = true;
				}

				break;
		}

		return res;
	}

	public bool Remove(object what)
	{
		bool res = false;
		switch (what)
		{
			case ItemMaterial:
				if (materials.Contains(what as ItemMaterial))
				{
					materials.Remove(what as ItemMaterial);
					res = true;
				}
				break;
			case Product:
				if (products.Contains(what as Product))
				{
					int value = (what as Product).productValue;
					UpdateCurrency(GetCurrency() + value);
					products.Remove(what as Product);
					res = true;
				}
				break;
		}

		return res;
	}

	public void UpdateCurrency(int x)
	{
		m_currency = x;
		UpdateCurrencyText();
	}

	public void UpdateCurrencyText()
	{
		currency_text.text = "" + m_currency;
	}


}


