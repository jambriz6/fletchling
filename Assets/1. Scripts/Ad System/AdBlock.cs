using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New AdBlock", menuName = "Ad System/Ad Block")]
public class AdBlock : ScriptableObject
{
    public Sprite fullSizeAd;
    public Sprite infoSprite;
    public Sprite thumbnailSprite;
}
