using System;
using UnityEditor.SearchService;
using UnityEngine;

// NOTE: 	You can create a new timer in script, use the static CreateTimer method.
//			This timer's smallest unit is decisecond, which is good enough most of the time, although 
//			it technically works for smaller time value if not paused (unless you encounters floating point number imprecision, then skill issue ig ¯\_(ツ)_/¯)
//			If paused while the time is not rounded to first digit after whole number, the remaining time will be rounded up (EX: 5.672 --> 5.7)
//			Calling begin while timer has already started has no effect.\

public class Timer : MonoBehaviour
{
	const float TIME_UNIT = 0.1f;		//Change this if you need a smaller time unit, but in what situation do you want something smaller than .1 sec???
	public float duration = 60;
	[SerializeField] float time_left;
	public float timeRemaining
	{
		set { time_left = Mathf.Clamp(value,0,duration); }
		get { return time_left; }
	}
	public bool LoopTimer = false;
	public bool StartOnBegin;
	public bool destroyOnEnd;
	public delegate void TimerEvent();
	public event TimerEvent OnTimerEnded;
	private event TimerEvent OnTimerDestroyed;
	private bool isCountingDown;
	private bool paused = true;
	public bool isPaused
	{
		get { return paused; }
		set { SetPause(value); }
	}

	void Start()
	{
		if (StartOnBegin) { Begin(); }
	}

	public void Begin()
	{
		if (!isPaused) {return;}
		duration = Mathf.Clamp(duration, 0f, 86400f);
		timeRemaining = duration;
		isPaused = false;
	}

	private void _tick()
	{
		if (isPaused == true) { return; }

		timeRemaining -= TIME_UNIT;

		if (timeRemaining > TIME_UNIT) { Invoke("_tick", TIME_UNIT); }
		else if (timeRemaining > 0) { Invoke("_tick", timeRemaining); }
		else Stop();
		if (LoopTimer) {Begin();}
	}

	private void SetPause(bool value)
	{
		paused = value;
		if (value == false) { _tick(); }
	}

	public void Stop()
	{
		timeRemaining = 0;
		isPaused = true;
		OnTimerEnded?.Invoke();
		if (destroyOnEnd) { Component.Destroy(this); }
	}

	void OnDestroy()
	{
		OnTimerDestroyed?.Invoke();
	}

	public static Timer CreateTimer(float Duration = 60, GameObject ObjectToAttach = null, bool looptimer = false, bool DestroyOnEnd = true, bool autoStart = true)
	{
		var is_object_valid = ObjectToAttach != null;
		if (!is_object_valid)
		{
			ObjectToAttach = new GameObject();
		}

		var timer = ObjectToAttach.AddComponent<Timer>();
		timer.duration = Duration;
		timer.destroyOnEnd = DestroyOnEnd;
		timer.StartOnBegin = autoStart;
		timer.LoopTimer = looptimer;

		if (!is_object_valid)
		{
			timer.OnTimerDestroyed += () => Destroy(ObjectToAttach);
		}
		return timer;
	}
}