using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTilesManager : MonoBehaviour
{
    #region Singleton
    public static AllTilesManager instance;
    private void Awake()
    {
        instance = this;

        for (int i = 0; i < allTiles.Count; i++)
        {
            allTiles[i].indexInAllTilesList = i;
        }
    }
    #endregion

    [SerializeField] private List<TileManager> allTiles;

    public List<TileManager> GetTilesList()
    {
        return allTiles;
    }
    
    public void GrowPlants()
    {
        foreach(TileManager tile in allTiles)
        {
            tile.GrowPlantDayCompleted();
        }
    }
}
