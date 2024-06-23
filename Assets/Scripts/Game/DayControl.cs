using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : ScriptableObject
{
    public enum Event{None,}
	public List<Product> WantedProducts = new List<Product>();
	public List<ItemMaterial> MaterialSold = new List<ItemMaterial>();
	public int CustomerCount;
	public int VendorCount;
	public int Quota;
}
