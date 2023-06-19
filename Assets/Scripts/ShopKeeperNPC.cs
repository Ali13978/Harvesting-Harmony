using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperNPC : MonoBehaviour
{
    [SerializeField] private CalenderSystem calenderSystem;
    [SerializeField] private Button NPCBtn;
    [SerializeField] private List<itemsPerSeason> storeItems;

    private List<SeedsItem> itemsInShop = new List<SeedsItem>();

    private void Start()
    {
        NPCBtn.onClick.AddListener(() => {
            UpdateShopItemsList();
            UIManager.instance.TurnOnSeedShopPannel();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        NPCBtn.gameObject.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        NPCBtn.gameObject.SetActive(false);
    }

    private void UpdateShopItemsList()
    {
        itemsInShop.Clear();

        int month = calenderSystem.GetDate()[1];
        
        foreach(SeedsItem seed in storeItems[month - 1].seed)
        {
            itemsInShop.Add(seed);
        }

        UIManager.instance.UpdateSeedShopPannel(itemsInShop);
    }
}

[System.Serializable]
class itemsPerSeason
{
    public List<SeedsItem> seed;
}

