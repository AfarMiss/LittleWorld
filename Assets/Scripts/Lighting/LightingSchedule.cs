using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "lightingSchedule_", menuName = "Scriptable Object/Lighting/LightingSchedule")]
public class LightingSchedule : ScriptableObject
{
    public LightingBrightness[] lightingBrightnesses;
}

[System.Serializable]
public struct LightingBrightness
{
    public int quarter;
    public int hour;
    public float lightIntensity;
}
