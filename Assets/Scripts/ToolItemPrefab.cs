using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolItemPrefab : MonoBehaviour
{
    [SerializeField] private ToolsItem tool;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Button SelectButton;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = tool.sprite;
        nameText.text = tool.name;
        
        SelectButton.onClick.AddListener(() => {
            ToolSelection.instance.SelectItem(tool);
            UIManager.instance.UpdateToolBtnImage(tool.sprite);
            UIManager.instance.TurnOffAllPannels();
        });
    }
    
}
