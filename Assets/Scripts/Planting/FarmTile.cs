using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmTile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer tileSpriteRenderer;
    [SerializeField] private SpriteRenderer cropSpriteRenderer;
    [SerializeField] private BoxCollider2D tileCollider;

    [SerializeField] private GameObject BuyCanvas;
    [SerializeField] private Button BuyBtn;

    [SerializeField] private TileManager tile;
    [SerializeField] private TileBuySellWindow tileBuySellWindow;

    private void Start()
    {
        BuyBtn.onClick.AddListener(() =>{
            tileBuySellWindow.gameObject.SetActive(true);
            tileBuySellWindow.UpdateTileBuySellWindow(tile.PriceTobuy, "Not enough money", () => {
                if (PlayerEconomy.instance.GetMoney() >= tile.PriceTobuy)
                {
                    tile.isOwned = true;

                    BuyCanvas.SetActive(false);
                    PlayerEconomy.instance.UpdateMoney(-1 * tile.PriceTobuy);
                    tileBuySellWindow.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(tileBuySellWindow.ErrorTextCoroutine());
                }
            });
        });
    }

    public void UpdateTileSpriteWithColor(Sprite sprite, Color color)
    {
        tileSpriteRenderer.sprite = sprite;
        tileSpriteRenderer.color = color;
    }

    public void UpdateCropSprite(Sprite sprite)
    {
        cropSpriteRenderer.sprite = sprite;
    }

    public void BuyCanvasSetActive(bool isActive)
    {
        BuyCanvas.SetActive(isActive);
    }

}
