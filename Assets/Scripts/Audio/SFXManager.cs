using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMOD;
using FMODUnity;
using UnityEditor;

class SFXManager : MonoBehaviour
{

    public StudioEventEmitter customer;
    public StudioEventEmitter vendor;

    void Start()
    {
    }

    public void PlayCustomer()
    {
        customer.Play();
        //customer.EventInstance.start();
    }

    public void PlayVendor()
    {
        vendor.Play();
    }

}