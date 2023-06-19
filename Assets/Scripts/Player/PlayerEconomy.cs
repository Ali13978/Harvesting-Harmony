using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    [SerializeField] private int money;

    private void Start()
    {
        money = ES3.Load("Current Money", 0);
    }

    private void UpdateMoney(int amount)
    {
        money += amount;
    }

    public int GetMoney()
    {
        return money;
    }
}
