using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MachineManager : Singleton<MachineManager>
{
    public List<MachineBase> machines;
    public GameObject machinePrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach (MachineBase m in machines)
        {
            GameObject inst = Instantiate(machinePrefab);
            MachineRenderUI script = inst.gameObject.GetComponent<MachineRenderUI>();
            script.machine = m;
            script.Init();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyMachine(MachineBase machine)
    {
        machines.Add(machine);
        GameObject inst = Instantiate(machinePrefab);
        MachineRenderUI script = inst.gameObject.GetComponent<MachineRenderUI>();
        script.machine = machine;
        script.Init();
    }
}
