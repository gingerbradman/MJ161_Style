using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
	void Awake()
	{
		Global.DisplayInfo += DisplayDetails;
	}

	void DisplayDetails(object o)
	{
		switch (o)
		{
			case MachineLogic:
				break;
			case Item:
				break;
			case NPC:
				break;
			default:
				return;
		}
	}
}
