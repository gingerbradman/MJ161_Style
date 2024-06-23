using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private Image image;
    private float time = 0.0f;
    private bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    void OnDisable()
    {
        image.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.25) toggle();
    }

    void toggle()
    {
        image.color = on ? Color.red : Color.white;

        on = !on;
        time = 0;
    }
}
