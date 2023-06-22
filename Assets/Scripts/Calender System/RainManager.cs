using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    #region Singleton
    public static RainManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private RainController rainController;

    private bool isRaining = false;
    private List<TileManager> tiles;

    private void Start()
    {
        tiles = AllTilesManager.instance.GetTilesList();
    }

    private void Update()
    {
        if (!isRaining)
            return;

        foreach(TileManager tile in tiles)
        {
            if (!tile.isOwned)
                continue;
            if (tile.TileState != TileManager.state.Hoed)
                continue;

            tile.WaterTile();
        }
    }

    public void SetRaining(bool _isRaining)
    {
        if (_isRaining)
            rainController.OnRainChanged(0.6f);
        else
            rainController.OnRainChanged(0f);

        isRaining = _isRaining;
    }
}
