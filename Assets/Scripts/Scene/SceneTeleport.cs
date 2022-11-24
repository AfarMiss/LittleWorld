using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTeleport : MonoBehaviour
{
    [SerializeField] private SceneEnum nextScene;
    [SerializeField] private Vector2 telePosRef;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var realTelePos = telePosRef;

        //当坐标填为0时，沿用当前玩家的X/Y坐标
        if (Mathf.Approximately(telePosRef.x, 0))
        {
            realTelePos.x = Director.Instance.MainPlayer.transform.position.x;
        }
        if (Mathf.Approximately(telePosRef.y, 0))
        {
            realTelePos.y = Director.Instance.MainPlayer.transform.position.y;
        }

        SceneControllerManager.Instance.TryChangeScene(nextScene.ToString(), realTelePos);
    }
}
