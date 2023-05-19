using UnityEngine;
using Cinemachine;
using UnityEditor;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    /// <summary>
    /// Switch the collider that cinemachine uses to define the edges of the screen.
    /// </summary>
    private void SwitchBoundingShape()
    {
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner.ToString()).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        cinemachineConfiner.InvalidatePathCache();
    }

    private void OnEnable()
    {
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded, this);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded);
    }

    private void OnSceneLoaded()
    {
        SwitchBoundingShape();
    }
}
