using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AdSet", menuName = "Ad System/Ad Set")]
public class AdSet : ScriptableObject
{
    public AdBlock[] adBlocks;
}

