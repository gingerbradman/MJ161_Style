using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Global
{
	public delegate void Event();
	public delegate void Action(object o);
	public static Action DisplayInfo;
	public const string CANVAS_GROUP = "Canvas";

	public static Dictionary<T, int> ClampItems<T>(List<T> list)
	{
		var counted = new List<T>();
		var dict = new Dictionary<T, int>();
		foreach (var item in list)
		{
			if (counted.Contains(item)) {dict[item] += 1;}
			else 
			{
				dict.Add(item, 1);
				counted.Add(item);
			}
		}
		return dict;
	}
}
