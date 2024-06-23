using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Global;


public class MachineRenderUI : MachineLogic, IChoices
{
	[SerializeField] TMP_Text show_material;
	public GameObject popup{get => Popup;}
	[SerializeField] GameObject Popup;

	public void OnPopUpButtonPressed()
	{
		//popup.SetActive(!popup.activeSelf);
		UpdateText();
	}

	public void OnAcceptButtonPressed()
	{
		StartProduction();
		//popup.SetActive(!popup.activeSelf);
	}

	public void OnDeclineButtonPressed()
	{
		//popup.SetActive(!popup.activeSelf);
	}

	void UpdateText()
	{
		var text = "";
		var dict = ClampItems<ItemMaterial>(machine.materialsRequired);
		foreach (var entry in dict)
		{
			text += entry.Key.Name + " x" + entry.Value.ToString() + " ";
		}
		show_material.text = text;
	}
}
