using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Seed name", menuName = "Seed item", order = 1)]
public class SeedsItem : ScriptableObject
{
    public Sprite sprite;
    public List<Sprite> growthStages;
    public List<int> DaysToGrowEachStage;
    public SeedsItem foodItWillGrow;
    public string id;
    public int BuyPrice;
    public int SellPrice;
    public bool isPurchaseable;

    public bool isFood;
    public int strengthItGives;
}