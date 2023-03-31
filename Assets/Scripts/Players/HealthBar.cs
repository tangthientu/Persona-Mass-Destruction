using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;// chinh gia tri max cua value slider la mau toi da
        slider.value = health;//gia tri value = mau
        gradient.Evaluate(1f);//mau` gradient
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
