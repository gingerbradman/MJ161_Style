using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSlot : MonoBehaviour
{
    public MachineBase machine;
    // Start is called before the first frame update
    void Start()
    {
        machine.location = transform;
        Destroy(gameObject);
    }
}
