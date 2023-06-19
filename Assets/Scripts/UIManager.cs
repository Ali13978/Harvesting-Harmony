using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("ToolsInventoryPannel")]
    [SerializeField] private GameObject ToolsInventoryPannel;
    [SerializeField] private Button toolsInventoryBtn;

    [Header("SeedsShopPannel")]
    [SerializeField] private GameObject seedsShopPannel;
    [SerializeField] private GameObject seedsShopContent;
    [SerializeField] private GameObject seedsShopItemPrefab;
    [SerializeField] private Button exitSeedShopBtn;


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

    private void TurnOffAllPannels()
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

            //newItem.UpdateUI(seed.sprite, seed.BuyPrice, seed.SellPrice);
        }
    }
}
