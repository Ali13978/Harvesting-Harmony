using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ShopItemPrefab : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private TMP_Text buyPriceText;
    [SerializeField] private TMP_Text sellPriceText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;


    public void UpdateUI(Sprite _sprite, int _buyPrice, int _sellPrice, UnityAction BuyBtnAction, UnityAction SellBtnAction)
    {
        sprite.sprite = _sprite;
        buyPriceText.text = "Buy Price: " + _buyPrice.ToString() + "$";
        sellPriceText.text = "Sell Price: " + _sellPrice.ToString() + "$";
        buyButton.onClick.AddListener(BuyBtnAction);
        sellButton.onClick.AddListener(SellBtnAction);
    }
}
