using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] public int PriceTobuy = 30;
    [HideInInspector]public enum state {Basic, Hoed, Watered};
    [SerializeField] public state TileState;
    [SerializeField] private Sprite[] tileSprites;
    [SerializeField] private FarmTile tile;
    [SerializeField] public bool isOwned;

    public int indexInAllTilesList;
    
    public bool isPlanted;
    public SeedsItem plantedSeed;
    public int growthIndex;
    public int daysLeftforNextGrowthStage;

    private void Start()
    {
        isOwned = ES3.Load("Tile" + indexInAllTilesList + "isOwned", false);
        TileState = ES3.Load("Tile" + indexInAllTilesList + "tileState", state.Basic);
        isPlanted = ES3.Load("Tile" + indexInAllTilesList + "isPlanted", false);
        plantedSeed = ES3.Load("Tile" + indexInAllTilesList + "plantedSeed", new SeedsItem());
        growthIndex = ES3.Load("Tile" + indexInAllTilesList + "growthIndex", 0);
        daysLeftforNextGrowthStage = ES3.Load("Tile" + indexInAllTilesList + "daysLeftforNextGrowthStage", 0);


        if (isOwned)
            tile.BuyCanvasSetActive(false);
        if (TileState == state.Hoed || TileState == state.Watered)
            HoeTile();
        if(isPlanted)
            tile.UpdateCropSprite(plantedSeed.growthStages[growthIndex]);
    }

    public void HoeTile()
    {
        TileState = state.Hoed;
        tile.UpdateTileSpriteWithColor(tileSprites[1], Color.white);
    }

    public void WaterTile()
    {
        TileState = state.Watered;
        tile.UpdateTileSpriteWithColor(tileSprites[2], Color.HSVToRGB(0f, 0f, 62f / 100f));
    }

    public void BaseTile()
    {
        TileState = state.Basic;
        tile.UpdateTileSpriteWithColor(tileSprites[1], Color.white);
    }

    public state GetTileState()
    {
        return TileState;
    }

    public bool GetIsPlanted()
    {
        return isPlanted;
    }

    public void PlantSeed(SeedsItem seed)
    {
        isPlanted = true;
        plantedSeed = seed;
        PlayerInventory.instance.RemoveSeedInInventory(plantedSeed);
        growthIndex = 0;
        daysLeftforNextGrowthStage = seed.DaysToGrowEachStage[growthIndex];

        tile.UpdateCropSprite(plantedSeed.growthStages[growthIndex]);
    }

    public void GrowPlant()
    {

    }
}
