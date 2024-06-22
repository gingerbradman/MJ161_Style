using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MachineLogic : RenderedObject
{
    event Global.Event MachineStarted;
	Timer ProductionTimer;
	bool InProduction;
	[SerializeField] List<ItemMaterial> materialsRequired;
	[SerializeField] Product product;
	[SerializeField] float ProductionTime = 3f;

	void Start()
	{
		ProductionTimer = Timer.CreateTimer(ProductionTime, gameObject, true, false, false);
		ProductionTimer.OnTimerEnded += OnTimerEnded;
		
	}

	public void StartProduction()
	{
		if (InProduction) {return; }
		var p = GameManager.Instance.player.materials;
		var inv = new List<ItemMaterial>(p);
		foreach (var mat in materialsRequired)
		{
			var hasMaterial = false;
			foreach (var m in inv)
			{
				if (m.Name == mat.Name)
				{
					inv.Remove(m);
					hasMaterial = true;
					break;
				}
			}
			if (!hasMaterial) {return;}
		}

		foreach (var mat in materialsRequired)
		{
			foreach (var m in p)
			{
				if (m == mat)
				{
					p.Remove(m);
					break;
				}
			}
		}

		ProductionTimer.Begin();
		InProduction = true;
		MachineStarted?.Invoke();
	}

	public void OnClicked()
	{
		Global.DisplayInfo?.Invoke(this);
		Debug.Log(this);
	}

	void OnTimerEnded()
	{
		InProduction = false;
		GameManager.Instance.player.Append(product);
	}
}
