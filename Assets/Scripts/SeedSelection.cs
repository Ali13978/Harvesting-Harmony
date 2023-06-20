using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSelection : MonoBehaviour
{
    #region Singleton
    public static SeedSelection instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private SeedsItem SelectedSeed;

    public void SelectItem(SeedsItem item)
    {
        SelectedSeed = item;
    }

    public SeedsItem GetSelectedSeed()
    {
        return SelectedSeed;
    }
}
