using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DayControl : ScriptableObject
{
    public enum Event{None,}
	public int CustomerCount;
	public int Quota;
}
