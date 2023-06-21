using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthUI : MonoBehaviour
{
    [SerializeField] Slider strengthSlider;
    

    public void UpdateStrengthUI(int strength, int maxStrength)
    {
        strengthSlider.maxValue = maxStrength;
        strengthSlider.value = strength;
    }
}
