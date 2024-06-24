using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MachineButton : MonoBehaviour
{
    //public List<MachineBase> machinesToPurchase;
    //public List<MachineBase> ownedMachines;
    Button m_button;
    public MachineBase m_machine;
    GameObject machineShop;

    void Start() {
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(delegate { Buy(); });
        machineShop = GameObject.Find("MachineShop");
    }

    public void Buy()
    {
        PlayerStorage player = GameManager.Instance.player;
        int current_currency = player.GetCurrency();
        if (current_currency > m_machine.cost)
        {
            player.UpdateCurrency(current_currency - m_machine.cost);
            gameObject.SetActive(false);
            machineShop.SetActive(false);
            MachineManager.Instance.BuyMachine(m_machine);
        }

    }
}
