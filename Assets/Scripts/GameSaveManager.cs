using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES3Types;

public class GameSaveManager : MonoBehaviour
{
    #region singleton
    public static GameSaveManager instance;
    private void Awake()
    {

        instance = this;
    }
    #endregion
    [SerializeField] private CalenderSystem calenderSystem;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerEconomy playerEconomy;

    private void SaveDate(List<int> date)
    {
        ES3.Save("Date", date);
    }

    private void SaveInventory(Dictionary<SeedsItem, int> seedsInventory)
    {
        ES3.Save("Seeds In Inventory", seedsInventory);
    }

    private void SaveMoney(int Money)
    {
        ES3.Save("SaveMoney", Money);
    }

    public void SaveGame()
    {
        SaveDate(calenderSystem.GetDate());
        SaveInventory(playerInventory.GetSeedsInInventory());
        SaveMoney(playerEconomy.GetMoney());
    }
}
