using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private InventoryUI inventoryUI;

    [SerializeField] private List<SeedsItem> seedsSOs = new List<SeedsItem>();
    
    private List<SeedsItem> currentListForSeeds = new List<SeedsItem>();

    private Dictionary<SeedsItem, int> seedsInventory = new Dictionary<SeedsItem, int>();
        
    private void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();

        //Load Seeds
        if (!ES3.KeyExists("Seeds In Inventory"))
            ES3.Save("Seeds In Inventory", seedsInventory);
        else
            seedsInventory = ES3.Load("Seeds In Inventory", new Dictionary<SeedsItem,int>());

        seedsSOs.Clear();
        foreach(var kvr in seedsInventory)
        {
            for(int i = 1; i <= kvr.Value; i++)
                seedsSOs.Add(kvr.Key);
        }

        currentListForSeeds.AddRange(seedsSOs);

        seedsInventory = CalculateSeedCounts();
        inventoryUI.UpdateInventoryUI(seedsInventory);

    }
    
    private void Update()
    {
        if (HasListChanged(seedsSOs, ref currentListForSeeds))
        {
            seedsInventory = CalculateSeedCounts();
            inventoryUI.UpdateInventoryUI(seedsInventory);
        }

    }

    private bool HasListChanged<T>(List<T> originalList,ref List<T> currentList)
    {
        if (originalList.Count != currentList.Count)
        {
            currentList.Clear();
            currentList.AddRange(originalList);
            return true;
        }

        for (int i = 0; i < originalList.Count; i++)
        {
            if (!originalList[i].Equals(currentList[i]))
            {
                currentList.Clear();
                currentList.AddRange(originalList);
                return true;
            }
        }

        return false;
    }

    #region Check number of seeds in stack per SeedsItem
    public class SeedsItemComparer : IEqualityComparer<SeedsItem>
    {
        public bool Equals(SeedsItem x, SeedsItem y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(SeedsItem obj)
        {
            return obj.id.GetHashCode();
        }
    }

    // Calculate the number of seeds for each SeedsItem
    public Dictionary<SeedsItem, int> CalculateSeedCounts()
    {
        Dictionary<SeedsItem, int> seedCounts = new Dictionary<SeedsItem, int>(new SeedsItemComparer());

        foreach (SeedsItem seedItem in seedsSOs)
        {
            if (seedCounts.ContainsKey(seedItem))
            {
                seedCounts[seedItem]++;
            }
            else
            {
                seedCounts[seedItem] = 1;
            }
        }

        return seedCounts;
    }
    #endregion

    public Dictionary<SeedsItem, int> GetSeedsInInventory()
    {
        seedsInventory = CalculateSeedCounts();
        return seedsInventory;
    }

    public void AddSeedInInventory(SeedsItem seed)
    {
        seedsSOs.Add(seed);
    }

    public void RemoveSeedInInventory(SeedsItem seed)
    {
        seedsSOs.Remove(seed);
    }

    public int GetNumberOfSeedsPerId(string id)
    {
        // Output the seed counts to the console
        foreach (var kvp in seedsInventory)
        {
            SeedsItem seed = kvp.Key;
            
            if(seed.id == id)
            {
                return kvp.Value;
            }
        }

        return 0;
    }
}
