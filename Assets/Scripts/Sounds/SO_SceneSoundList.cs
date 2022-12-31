using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_SceneSoundsList", menuName = "Scriptable Object/Sounds/Scene Sounds List")]
public class SO_SceneSoundList : ScriptableObject
{
    [SerializeField]
    public List<SceneSoundItem> sceneSoundsDetails;
}
