using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorSwap
{
    public Color fromColor;
    public Color toColor;

    public ColorSwap(Color fromColor, Color toColor)
    {
        this.fromColor = fromColor;
        this.toColor = toColor;
    }
}
