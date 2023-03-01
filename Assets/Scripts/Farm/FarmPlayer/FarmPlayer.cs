using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmPlayer : MonoSingleton<FarmPlayer>, ISaveable
{
    protected override void Awake()
    {
        base.Awake();
        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }
    public SpriteRenderer EquipRenderer => equipRenderer;


    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get { return iSaveableUniqueID; } set { iSaveableUniqueID = value; } }
    private GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get { return gameObjectSave; } set { gameObjectSave = value; } }

    [SerializeField] private SpriteRenderer equipRenderer;

    public Vector3 GetPlayrCentrePosition()
    {
        return new Vector3(transform.position.x, transform.position.y + GameSetting.playerCentreYOffset, transform.position.z);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Remove(this);
    }

    public void ISaveableStoreScene(string sceneName)
    {
    }

    public void ISaveableRestoreScene(string sceneName)
    {
    }

    public GameObjectSave ISaveableSave()
    {
        GameObjectSave.sceneData.Remove(GameSetting.PersistentScene);

        SceneSave sceneSave = new SceneSave();
        sceneSave.vector3Dictionary = new Dictionary<string, Vector3Serializable>();
        sceneSave.stringDictionary = new Dictionary<string, string>();
        Vector3Serializable vector3Serializable = new Vector3Serializable(transform.position.x, transform.position.y, transform.position.z);
        sceneSave.vector3Dictionary.Add("playerPosition", vector3Serializable);
        sceneSave.stringDictionary.Add("currentScene", SceneManager.GetActiveScene().name);

        var dirString = Direction.none;
        if (FarmGameController.Instance.PlayerDirection == Vector2Int.up)
        {
            dirString = Direction.up;
        }
        if (FarmGameController.Instance.PlayerDirection == Vector2Int.down)
        {
            dirString = Direction.down;
        }
        if (FarmGameController.Instance.PlayerDirection == Vector2Int.left)
        {
            dirString = Direction.left;
        }
        if (FarmGameController.Instance.PlayerDirection == Vector2Int.right)
        {
            dirString = Direction.right;
        }
        sceneSave.stringDictionary.Add("playerDirection", dirString.ToString());

        GameObjectSave.sceneData.Add(GameSetting.PersistentScene, sceneSave);

        return GameObjectSave;
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            if (gameObjectSave.sceneData.TryGetValue(GameSetting.PersistentScene, out SceneSave sceneSave))
            {
                if (sceneSave.vector3Dictionary != null && sceneSave.vector3Dictionary.TryGetValue("playerPosition", out Vector3Serializable playerPosition))
                {
                    transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
                }

                if (sceneSave.stringDictionary != null)
                {
                    if (sceneSave.stringDictionary.TryGetValue("currentScene", out string currentScene))
                    {
                        SceneControllerManager.Instance.TryChangeScene(currentScene);
                    }

                    if (sceneSave.stringDictionary.TryGetValue("playerDirection", out string playerDir))
                    {
                        bool playerDirFound = Enum.TryParse<Direction>(playerDir, true, out Direction direction);

                        if (playerDirFound)
                        {
                            Vector3Int dirEnum = Vector3Int.zero;
                            if (direction == Direction.up)
                            {
                                dirEnum = Vector3Int.up;
                            }
                            else if (direction == Direction.down)
                            {
                                dirEnum = Vector3Int.down;
                            }
                            else if (direction == Direction.right)
                            {
                                dirEnum = Vector3Int.right;
                            }
                            else if (direction == Direction.left)
                            {
                                dirEnum = Vector3Int.left;
                            }
                            //FarmGameController.Instance.PlayerDirection = dirEnum;
                        }
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        ISaveableRegister();
    }

    private void OnDisable()
    {
        ISaveableDeregister();
    }
}
