using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
	public int Day;
	public event Global.Event DayEnded;
	public event Global.Event DayStarted;
	public Timer DayTimer;

	void Awake()
	{
		DayTimer.OnTimerEnded += EndDay;
	}

	public void StartDay()
	{
		DayTimer.Begin();
		DayStarted?.Invoke();
	}

	public void EndDay()
	{
		DayEnded?.Invoke();
	}
}