using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MachineLogic : RenderedObject
{
    public event Global.Event MachineStarted;
	protected Timer ProductionTimer;
	public bool InProduction;
	[SerializeField] protected MachineBase machine;

	void Start()
	{
		ProductionTimer = Timer.CreateTimer(machine.ProductionTime, gameObject, true, false, false);
		ProductionTimer.OnTimerEnded += OnTimerEnded;
		renderObject.GetComponent<Image>().sprite = machine.sprite;
	}

	public void StartProduction()
	{
		if (!CheckRequirementMet() || InProduction) {return; }
		foreach (var mat in machine.materialsRequired)
		{
			foreach (var m in GameManager.Instance.player.materials)
			{
				if (m == mat)
				{
					GameManager.Instance.player.materials.Remove(m);
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
		GameManager.Instance.player.Append(machine.product);
	}

	bool CheckRequirementMet()
	{
		var p = GameManager.Instance.player.materials;
		var inv = new List<ItemMaterial>(p);
		foreach (var mat in machine.materialsRequired)
		{
			var hasMaterial = false;
			foreach (var m in inv)
			{
				if (m == mat)
				{
					inv.Remove(m);
					hasMaterial = true;
					break;
				}
			}
			if (!hasMaterial) {return false;}
		}

		return true;
	}
}
