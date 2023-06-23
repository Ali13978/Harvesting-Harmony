using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFood : MonoBehaviour
{
    #region Singleton
    public static PlayerFood instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] int maxStrength;
    [SerializeField] int playerStrength;

    StrengthUI strengthUI;

    private void Start()
    {
        strengthUI = GetComponent<StrengthUI>();
        
        playerStrength = maxStrength;

        strengthUI.UpdateStrengthUI(playerStrength, maxStrength);
    }

    public int GetStrength()
    {
        return playerStrength;
    }

    public bool AlreadyHaveFullStrength()
    {
        bool haveStr = (playerStrength >= maxStrength);
        return haveStr;
    }

    public void ResetStrength()
    {
        UpdateStrength(maxStrength);
    }

    public void UpdateStrength(int amount)
    {
        playerStrength += amount;

        if (playerStrength > maxStrength)
            playerStrength = maxStrength;
        if (playerStrength < 0)
            playerStrength = 0;

        strengthUI.UpdateStrengthUI(playerStrength, maxStrength);
    }
}
