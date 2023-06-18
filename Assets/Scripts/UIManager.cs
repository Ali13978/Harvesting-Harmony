using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject SeedsInventoryPannel;
    [SerializeField] private Button seedsInventoryBtn;

    private void Start()
    {
        TurnOffAllPannels();

        seedsInventoryBtn.onClick.AddListener(()=>{
            if (!SeedsInventoryPannel.activeInHierarchy)
                SeedsInventoryPannel.SetActive(true);
            else
                SeedsInventoryPannel.SetActive(false);
    });


    }

    private void TurnOffAllPannels()
    {
        SeedsInventoryPannel.SetActive(false);
    }
}
