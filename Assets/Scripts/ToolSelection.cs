using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelection : MonoBehaviour
{
    #region Singleton
    public static ToolSelection instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private ToolsItem SelectedItem;

    public void SelectItem(ToolsItem item)
    {
        SelectedItem = item;
    }

}
