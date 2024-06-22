using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Product : Item
{
	[Multiline]
	public string productDescription;
	public int productValue;
}
