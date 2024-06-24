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
    public StudioEventEmitter music;

    void Start()
    {
        GameManager.Instance.daySystem.DayStarted += MusicStart;
        GameManager.Instance.daySystem.DayEnded += MusicEnd;
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

    public void MusicStart() {
        music.Play();
    }

    public void MusicEnd() {
        music.Stop();
    }

}