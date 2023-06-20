using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    PlayerInventory playerInventory;

    [SerializeField] InventoryUIModules InventoryModules;
    private List<string> SeedsIds = new List<string>();

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    public void UpdateInventoryUI(Dictionary<SeedsItem, int> seedCounts)
    {
        List<GameObject> childObjects = new List<GameObject>();

        // Get all child GameObjects of Obj and add them to the list
        for (int i = 0; i < InventoryModules.Content.childCount; i++)
        {
            GameObject childObject = InventoryModules.Content.GetChild(i).gameObject;
            childObjects.Add(childObject);
        }

        foreach(GameObject i in childObjects)
        {
            Destroy(i);
        }
        // Output the seed counts to the console
        foreach (var kvp in seedCounts)
        {
            SeedsItem seed = kvp.Key;
            int count = kvp.Value;

            Debug.Log(", ID: " + seed.id + ", Count: " + count);
            GameObject InstantiatedSeed = Instantiate(InventoryModules.PrefabOfSeeds, InventoryModules.Content);

            InstantiatedSeed.GetComponent<Button>().onClick.AddListener(() => {
                if (!seed.isFood)
                {
                    SeedSelection.instance.SelectItem(seed);
                    UIManager.instance.UpdateSeedBtnImage(seed.sprite);
                    UIManager.instance.TurnOffAllPannels();
                }
                else
                {
                    PlayerFood.instance.UpdateStrength(seed.strengthItGives);
                    playerInventory.RemoveSeedInInventory(seed);
                }
            });

            InstantiatedSeed.GetComponent<Image>().sprite = seed.sprite;
            InstantiatedSeed.GetComponentInChildren<TMP_Text>().text = "x" + count.ToString();
        }

    }
}

[System.Serializable]
class InventoryUIModules
{
    public Transform Content;
    public GameObject PrefabOfSeeds;
}
