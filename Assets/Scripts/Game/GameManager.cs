using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public PlayerStorage player;
	public DaySystem daySystem;
	public QuotaSystem quotaSystem;
	protected override void OnAwake()
	{
		player = ScriptableObject.Instantiate(player);
	}
}
