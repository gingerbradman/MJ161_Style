using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public PlayerStorage player;
	public DaySystem daySystem;
	public QuotaSystem quotaSystem;
	public NPCPool CustomerPool;
	public List<Product> ProductUnlocked = new List<Product>();
	public List<Sprite> CustomerSprites = new List<Sprite>();
	protected override void OnAwake()
	{
		player = ScriptableObject.Instantiate(player);
	}
}
