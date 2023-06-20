using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("SeedsInventoryPannel")]
    [SerializeField] private GameObject SeedsInventoryPannel;
    [SerializeField] private Button seedsInventoryBtn;
    [SerializeField] private Image seedsIventoryBtnImage;

    [Header("ToolsInventoryPannel")]
    [SerializeField] private GameObject ToolsInventoryPannel;
    [SerializeField] private Button toolsInventoryBtn;
    [SerializeField] private Image toolsIventoryBtnImage;

    [Header("SeedsShopPannel")]
    [SerializeField] private GameObject seedsShopPannel;
    [SerializeField] private GameObject seedsShopContent;
    [SerializeField] private GameObject seedsShopItemPrefab;
    [SerializeField] private Button exitSeedShopBtn;

    [Header("Buy Sell Window")]
    [SerializeField] private BuySellWindow buySellWindow;

    private void Start()
    {
        TurnOffAllPannels();

        seedsInventoryBtn.onClick.AddListener(()=>{
            if (!SeedsInventoryPannel.activeInHierarchy)
            {
                TurnOffAllPannels();
                SeedsInventoryPannel.SetActive(true);
            }
            else
                SeedsInventoryPannel.SetActive(false);
        });

        toolsInventoryBtn.onClick.AddListener(() => {
            if (!ToolsInventoryPannel.activeInHierarchy)
            {
                TurnOffAllPannels();
                ToolsInventoryPannel.SetActive(true);
            }
            else
                ToolsInventoryPannel.SetActive(false);
        });

        exitSeedShopBtn.onClick.AddListener(()=> TurnOffAllPannels());
    }

    public void TurnOffAllPannels()
    {
        SeedsInventoryPannel.SetActive(false);
        ToolsInventoryPannel.SetActive(false);
        seedsShopPannel.SetActive(false);
    }


    public void TurnOnSeedShopPannel()
    {
        TurnOffAllPannels();
        seedsShopPannel.SetActive(true);
    }
    
    public void UpdateSeedShopPannel(List<SeedsItem> seeds)
    {
        List<GameObject> childObjects = new List<GameObject>();

        // Get all child GameObjects of Obj and add them to the list
        for (int i = 0; i < seedsShopContent.transform.childCount; i++)
        {
            GameObject childObject = seedsShopContent.transform.GetChild(i).gameObject;
            childObjects.Add(childObject);
        }

        foreach (GameObject i in childObjects)
        {
            Destroy(i);
        }

        foreach(SeedsItem seed in seeds)
        {
            ShopItemPrefab newItem = Instantiate(seedsShopItemPrefab, seedsShopContent.transform).GetComponent<ShopItemPrefab>();

            if (!seed.isPurchaseable)
                newItem.buyButtonSetActive(false);

            UnityAction buyBtnAction = ()=>{
                buySellWindow.UpdateBuySellWindow("Are you sure to buy", "How many " + seed.id + " You want to buy", "Not enough money to buy");
                buySellWindow.SetSeed(seed);
                buySellWindow.SetState(BuySellWindow.state.buy);
                buySellWindow.gameObject.SetActive(true);
            }; 
            UnityAction sellBtnAction = ()=> {
                buySellWindow.UpdateBuySellWindow("Are you sure to sell", "How many " + seed.id + " you want to sell", "Not enough items to sell");
                buySellWindow.SetSeed(seed);
                buySellWindow.SetState(BuySellWindow.state.sell);
                buySellWindow.gameObject.SetActive(true);
            };
            newItem.UpdateUI(seed.sprite, seed.BuyPrice, seed.SellPrice, buyBtnAction, sellBtnAction);
        }
    }


    public void UpdateToolBtnImage(Sprite sprite)
    {
        toolsIventoryBtnImage.sprite = sprite;
    }

    public void UpdateSeedBtnImage(Sprite sprite)
    {
        seedsIventoryBtnImage.sprite = sprite;
    }
}
