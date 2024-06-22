using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
	public delegate void Event();
	public delegate void Action(object o);
	public static Action DisplayInfo;
	public const string CANVAS_GROUP = "Canvas";
}
