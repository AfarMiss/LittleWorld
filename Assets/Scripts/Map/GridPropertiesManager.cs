using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class GridPropertiesManager : MonoSingleton<GridPropertiesManager>, ISaveable
{
    /// <summary>
    /// 当前地图格子设置信息
    /// </summary>
    public Grid grid;
    /// <summary>
    /// 当前地图信息
    /// </summary>
    private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;
    [SerializeField]
    private SO_GridProperties[] so_gridPropertiesArray = null;

    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }

    //目前两个GridPropertiesManager和SceneItemManager分别使用了不同的GameObjectSave变量并分别存储，虽然没有问题，但造成了内存的浪费。
    private GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    protected override void Awake()
    {
        base.Awake();
        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    private void OnEnable()
    {
        ISaveableRegister();
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoaded);
    }

    private void OnDisable()
    {
        ISaveableDeregister();
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoaded);
    }

    private void AfterSceneLoaded()
    {
        grid = GameObject.FindObjectOfType<Grid>();
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Remove(this);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Add(this);
    }

    private void Start()
    {
        InitialiseGridProperties();
    }

    private void InitialiseGridProperties()
    {
        foreach (var so_GridProperties in so_gridPropertiesArray)
        {
            Dictionary<string, GridPropertyDetails> gridPropertyDictionary = new Dictionary<string, GridPropertyDetails>();

            foreach (var gridProperty in so_GridProperties.gridPropertyList)
            {
                GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDictionary);
                if (gridPropertyDetails == null)
                {
                    gridPropertyDetails = new GridPropertyDetails();
                }

                switch (gridProperty.gridBoolProperty)
                {
                    case GridBoolProperty.diggable:
                        gridPropertyDetails.isDiggable = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.canDropItem:
                        gridPropertyDetails.canDropItem = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.canPlaceFurniture:
                        gridPropertyDetails.canPlaceFurniture = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.isPath:
                        gridPropertyDetails.isPath = gridProperty.gridBoolValue;
                        break;
                    case GridBoolProperty.isNPCObstacle:
                        gridPropertyDetails.isNPCObstacle = gridProperty.gridBoolValue;
                        break;
                    default:
                        break;
                }

                SetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDetails, gridPropertyDictionary);
            }

            SceneSave sceneSave = new SceneSave();
            sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;
            if (so_GridProperties.sceneName == SceneControllerManager.Instance.startingSceneName)
            {
                this.gridPropertyDictionary = gridPropertyDictionary;
            }
            GameObjectSave.sceneData.Add(so_GridProperties.sceneName.ToString(), sceneSave);
        }
    }

    private void SetGridPropertyDetails(int x, int y, GridPropertyDetails gridPropertyDetails, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = $"x{x}y{y}";
        gridPropertyDetails.gridX = x;
        gridPropertyDetails.gridY = y;

        gridPropertyDictionary[key] = gridPropertyDetails;
    }

    private GridPropertyDetails GetGridPropertyDetails(int x, int y, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = $"x{x}y{y}";
        GridPropertyDetails propertyDetails;
        if (!gridPropertyDictionary.TryGetValue(key, out propertyDetails))
        {
            return null;
        }
        else
        {
            return propertyDetails;
        }
    }

    public GridPropertyDetails GetGridPropertyDetails(int x, int y)
    {
        return GetGridPropertyDetails(x, y, gridPropertyDictionary);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.gridPropertyDetailsDictionary != null)
            {
                gridPropertyDictionary = sceneSave.gridPropertyDetailsDictionary;
            }
        }
    }

    public void ISaveableStoreScene(string sceneName)
    {
        GameObjectSave.sceneData.Remove(sceneName);
        SceneSave sceneSave = new SceneSave();
        sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;
        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }
}
