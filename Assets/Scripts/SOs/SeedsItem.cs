using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Seed name", menuName = "Seed item", order = 1)]
public class SeedsItem : ScriptableObject
{
    public Sprite sprite;
    public List<Sprite> growthStages;
    public List<int> DaysToGrowEachStage;
    public string id;
}