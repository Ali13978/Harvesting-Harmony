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

    [SerializeField] private PlayerEconomy playerEconomy;
    [SerializeField] private PlayerInventory playerInventory;

    private int Amount = 0;

    [HideInInspector] public enum state
    {
        nothing,
        buy,
        sell
    }

    private state State = state.nothing;

    private SeedsItem seed;

    private void Start()
    {
        NoBtn.onClick.AddListener(() => {
            State = state.nothing;
            seed = null;
            Amount = 0;
            errorText.gameObject.SetActive(false);
            gameObject.SetActive(false);
        });


        amountInputField.onValueChanged.AddListener((string changedString) => {
            if (seed == null)
                return;
            if (changedString == "")
                return;

            int valueEntered = int.Parse(changedString);

            if(State == state.buy)
            {
                Amount = valueEntered * seed.BuyPrice;
                UpdateExpectedAmount(Amount);

                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(() => {
                    Buy(valueEntered);
                });
            }

            else if(State == state.sell)
            {
                Amount = valueEntered;
                UpdateExpectedAmount(Amount * seed.SellPrice);

                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(()=> {
                    Sell(Amount * seed.SellPrice);
                });
            }
        });
    }
    
    private void Buy(int numberOfSeeds)
    {
        if (Amount == 0)
            return;
        if (playerEconomy.GetMoney() < Amount)
        {
            StartCoroutine(ShowError());
            return;
        }

        for(int i = 1; i <= numberOfSeeds; i++)
        {
            playerInventory.AddSeedInInventory(seed);
        }
        playerEconomy.UpdateMoney(-1 * Amount);

        gameObject.SetActive(false);
    }

    private void Sell(int moneyEarned)
    {
        if (Amount == 0)
            return;
        if (playerInventory.GetNumberOfSeedsPerId(seed.id) < Amount)
        {
            StartCoroutine(ShowError());
            return;
        }
        for (int i = 1; i <= Amount; i++)
        {
            playerInventory.RemoveSeedInInventory(seed);
        }
        playerEconomy.UpdateMoney(moneyEarned);

        gameObject.SetActive(false);
    }

    IEnumerator ShowError()
    {
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        errorText.gameObject.SetActive(false);
    }

    public void SetState(state _state)
    {
        State = _state;
    }
    
    public void UpdateBuySellWindow(string _titleText, string _infoText, string _errorText)
    {
        titleText.text = _titleText;
        infoText.text = _infoText;
        errorText.text = _errorText;
        amountInputField.text = "";
    }

    public void SetSeed(SeedsItem _seed)
    {
        seed = _seed;
    }

    private void UpdateExpectedAmount(int amount)
    {
        expectedAmountText.text = "Expected Amount: " + amount.ToString();
    }
}
