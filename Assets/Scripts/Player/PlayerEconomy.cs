using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    #region Singleton
    public static PlayerEconomy instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private int money;

    private EconomyUI economyUI;

    private void Start()
    {
        economyUI = GetComponent<EconomyUI>();

        money = ES3.Load("Current Money", 0);

        economyUI.UpdateEconomyText(money);
    }

    public void UpdateMoney(int amount)
    {
        money += amount;
        economyUI.UpdateEconomyText(money);
    }

    public int GetMoney()
    {
        return money;
    }
}
