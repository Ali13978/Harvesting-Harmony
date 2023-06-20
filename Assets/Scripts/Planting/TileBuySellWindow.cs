using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TileBuySellWindow : MonoBehaviour
{

    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private Button YesBtn;
    [SerializeField] private Button NoBtn;

    private void Start()
    {
        NoBtn.onClick.AddListener(() => {
            errorText.gameObject.SetActive(false);
            gameObject.SetActive(false);
        });
    }

    public void UpdateTileBuySellWindow(int price, string errorString, UnityAction yesBtnAction)
    {
        priceText.text = "Price: " + price;
        errorText.text = errorString;

        YesBtn.onClick.RemoveAllListeners();
        YesBtn.onClick.AddListener(yesBtnAction);
    }

    public IEnumerator ErrorTextCoroutine()
    {
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        errorText.gameObject.SetActive(false);
    }
}
