using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text economyText;

    public void UpdateEconomyText(int Value)
    {
        economyText.text = Value.ToString();
    }
}
