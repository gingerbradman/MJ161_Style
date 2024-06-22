using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStorage : ScriptableObject
{
    public List<ItemMaterial> materials = new List<ItemMaterial>();
	public List<Product> products = new List<Product>();
	public int Currency = 10;

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
}


