using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaySystem : MonoBehaviour
{
	public int Day = 1;
	public event Global.Event DayEnded;
	public event Global.Event DayStarted;
	public Timer DayTimer;
	public TMP_Text dayText;

	void Awake()
	{
		DayTimer.OnTimerEnded += EndDay;
		dayText.text = ""+Day;
	}

	public void StartDay()
	{
		DayTimer.Begin();
		DayStarted?.Invoke();
		dayText.text = ""+Day;
	}

	public void EndDay()
	{
		if (DayTimer && !DayTimer.isPaused) {DayTimer.Stop();}
		Day += 1;
		DayEnded?.Invoke();
	}
}