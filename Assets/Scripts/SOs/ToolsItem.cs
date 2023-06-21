using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool name", menuName = "Tool item", order = 1)]
public class ToolsItem : ScriptableObject
{
    [HideInInspector] public enum tool
    {
        Bucket, Hoe
    }

    public tool ToolType;
    public string ToolName;
    public Sprite sprite;
    public int strengthReq;
    public AudioClip SFX;
}
