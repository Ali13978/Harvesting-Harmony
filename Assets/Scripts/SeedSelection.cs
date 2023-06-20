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

    [SerializeField] private SeedsItem SelectedItem;

    public void SelectItem(SeedsItem item)
    {
        SelectedItem = item;
    }

}
