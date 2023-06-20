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
    [SerializeField] int PlayerStrength;

    
    public void UpdateStrength(int amount)
    {
        PlayerStrength += amount;

        if (PlayerStrength > maxStrength)
            PlayerStrength = maxStrength;
        if (PlayerStrength < 0)
            PlayerStrength = 0;
    }
}
