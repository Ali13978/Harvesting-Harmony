using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuySellWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private TMP_InputField amountInputField;
    [SerializeField] private TMP_Text expectedAmountText;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private Button NoBtn;
    [SerializeField] private Button YesBtn;

    private void Start()
    {
        NoBtn.onClick.AddListener(() => { gameObject.SetActive(false); });
    }

    public int GetInputRes()
    {
        int inputvalue = int.Parse(amountInputField.text);
        Debug.Log(inputvalue);
        return inputvalue;
    }

    public void UpdateBuySellWindow(string titleText, string infoText)
    {

    }

    public void UpdateExpectedAmount(int amount)
    {

    }
}
