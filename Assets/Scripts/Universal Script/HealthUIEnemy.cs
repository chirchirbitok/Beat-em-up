using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIEnemy : MonoBehaviour
{
    private Image health_UI_Enemy;

    void Awake()
    {
        //find image component that hold the slider
        health_UI_Enemy = GameObject.FindWithTag(Tags.HEALTH_UI_ENEMY).GetComponent<Image>();
    }

    public void DisplayHealth1(float value)
    {
        //devide wih 100 becoz fillAmount ranges from 0 to 1    -99/100 = 0.99
        value /= 200;

        if (value < 0f)
            value = 0f;

        health_UI_Enemy.fillAmount = value;
    }
}
