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
    }

    private void TurnOffAllPannels()
    {
        SeedsInventoryPannel.SetActive(false);
        ToolsInventoryPannel.SetActive(false);
        seedsShopPannel.SetActive(false);
    }


}
