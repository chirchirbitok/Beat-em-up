using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image health_UI;

    void Awake()
    {
        //find image component that hold the slider
        health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
    }

    public void DisplayHealth(float value)
    {
        //devide wih 100 becoz fillAmount ranges from 0 to 1    -99/100 = 0.99
        value /= 200;

        if (value < 0f)
            value = 0f;

        health_UI.fillAmount = value;
    }
}
