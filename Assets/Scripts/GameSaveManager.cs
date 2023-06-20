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
    [SerializeField] AllTilesManager allTilesManager;

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
        ES3.Save("Current Money", Money);
    }

    private void SaveFarmTilesData(List<TileManager> allTiles)
    {
        foreach (TileManager tile in allTiles)
        {
            ES3.Save("Tile" + tile.indexInAllTilesList + "isOwned", tile.isOwned);
            ES3.Save("Tile" + tile.indexInAllTilesList + "tileState", tile.TileState);
            ES3.Save("Tile" + tile.indexInAllTilesList + "isPlanted", tile.isPlanted);
            ES3.Save("Tile" + tile.indexInAllTilesList + "plantedSeed", tile.plantedSeed);
            ES3.Save("Tile" + tile.indexInAllTilesList + "growthIndex", tile.growthIndex);
            ES3.Save("Tile" + tile.indexInAllTilesList + "daysLeftforNextGrowthStage", tile.daysLeftforNextGrowthStage);
        }
    }

    public void SaveGame()
    {
        SaveDate(calenderSystem.GetDate());
        SaveInventory(playerInventory.GetSeedsInInventory());
        SaveMoney(playerEconomy.GetMoney());
        SaveFarmTilesData(allTilesManager.GetTilesList());
    }
}
