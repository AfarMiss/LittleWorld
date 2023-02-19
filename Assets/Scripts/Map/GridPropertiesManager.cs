using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GenerateGUID))]
public class GridPropertiesManager : MonoSingleton<GridPropertiesManager>, ISaveable
{
    delegate bool JudgeGrid(int gridX, int gridY);

    private Transform cropParentTransform;

    private Tilemap waterLayer;
    private Tilemap plainLayer;
    private bool isFirstTimeSceneLoaded = true;
    /// <summary>
    /// 当前地图信息
    /// </summary>
    private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;

    [SerializeField]
    private SO_CropDetailsList so_CropDetailsList = null;
    [SerializeField]
    private SO_GridProperties[] so_gridPropertiesArray = null;
    [SerializeField]
    private Tile[] dugGround = null;
    [SerializeField]
    private Tile[] waterGround = null;

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

    public SO_GridProperties GetActiveSceneGridProperties()
    {
        foreach (SO_GridProperties item in so_gridPropertiesArray)
        {
            if (SceneManager.GetActiveScene().name == item.sceneName.ToString())
            {
                return item;
            }
        }
        return null;
    }

    private void OnEnable()
    {
        ISaveableRegister();
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoaded);
        EventCenter.Instance?.Register<GameTime>(EventName.DAY_CHANGE, OnAdvanceDay);
        EventCenter.Instance?.Register<GridPropertyDetails>(EventEnum.GRID_MODIFY.ToString(), OnGridModify);

    }

    private void OnDisable()
    {
        ISaveableDeregister();
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoaded);
        EventCenter.Instance?.Unregister<GameTime>(EventName.DAY_CHANGE, OnAdvanceDay);
        EventCenter.Instance?.Unregister<GridPropertyDetails>(EventEnum.GRID_MODIFY.ToString(), OnGridModify);
    }

    private void OnGridModify(GridPropertyDetails details)
    {
        string key = $"x{details.gridX}y{details.gridY}";
        gridPropertyDictionary.TryGetValue(key, out var value);
        if (value != null)
        {
            gridPropertyDictionary[key] = details;
        }

        UpdateAllDetails();
    }

    private void AfterSceneLoaded()
    {
        if (GameObject.FindGameObjectWithTag(Tags.CropsParentTransform.ToString()) != null)
        {
            cropParentTransform = GameObject.FindGameObjectWithTag(Tags.CropsParentTransform.ToString()).transform;
        }
        else
        {
            cropParentTransform = null;
        }

        waterLayer = GameObject.FindGameObjectWithTag(Tags.Water.ToString())?.GetComponent<Tilemap>();
        plainLayer = GameObject.FindGameObjectWithTag(Tags.Plain.ToString())?.GetComponent<Tilemap>();
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

    private void ClearDisplayGrouondDecorations()
    {
        waterLayer?.ClearAllTiles();
        plainLayer?.ClearAllTiles();
    }

    private void ClearDisplayGridPropertyDetails()
    {
        ClearDisplayGrouondDecorations();

        ClearDisplayAllPlantedCrops();
    }

    private void ClearDisplayAllPlantedCrops()
    {
        Crop[] cropArray;
        cropArray = FindObjectsOfType<Crop>();

        foreach (var crop in cropArray)
        {
            Destroy(crop.gameObject);
        }
    }

    public void DisplayDugGroud(GridPropertyDetails gridPropertyDetails)
    {
        if (gridPropertyDetails.daysSinceDug > -1)
        {
            ConnectDugGround(gridPropertyDetails);
        }
    }

    public void DisplayWaterGroud(GridPropertyDetails gridPropertyDetails)
    {
        if (gridPropertyDetails.daysSinceWatered > -1)
        {
            ConnectWaterGround(gridPropertyDetails);
        }
    }

    private void ConnectDugGround(GridPropertyDetails gridPropertyDetails)
    {
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY);

        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        SetAdjacentGridPropertyDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
    }

    private void ConnectWaterGround(GridPropertyDetails gridPropertyDetails)
    {
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY);

        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        SetAdjacentGridPropertyWaterDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
    }

    private GridPropertyDetails SetAdjacentGridPropertyDetails(int gridX, int gridY)
    {
        GridPropertyDetails adjacentGridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile = SetTile(gridX, gridY, dugGround, IsGridDug);
            waterLayer.SetTile(new Vector3Int(gridX, gridY, 0), dugTile);
        }

        return adjacentGridPropertyDetails;
    }

    private GridPropertyDetails SetAdjacentGridPropertyWaterDetails(int gridX, int gridY)
    {
        GridPropertyDetails adjacentGridPropertyDetails;
        adjacentGridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceWatered > -1)
        {
            Tile waterTile = SetTile(gridX, gridY, waterGround, IsGridWatered);
            plainLayer.SetTile(new Vector3Int(gridX, gridY, 0), waterTile);
        }

        return adjacentGridPropertyDetails;
    }

    private Tile SetTile(int gridX, int gridY, Tile[] tiles, JudgeGrid judgeGridFunc)
    {
        bool upDug = judgeGridFunc(gridX, gridY + 1);
        bool downDug = judgeGridFunc(gridX, gridY - 1);
        bool leftDug = judgeGridFunc(gridX - 1, gridY);
        bool rightDug = judgeGridFunc(gridX + 1, gridY);

        if (!upDug && !downDug && !rightDug && !leftDug)
        {
            return tiles[0];
        }
        else if (!upDug && downDug && rightDug && !leftDug)
        {
            return tiles[1];
        }
        else if (!upDug && downDug && rightDug && leftDug)
        {
            return tiles[2];
        }
        else if (!upDug && downDug && !rightDug && leftDug)
        {
            return tiles[3];
        }
        else if (!upDug && downDug && !rightDug && !leftDug)
        {
            return tiles[4];
        }
        else if (upDug && downDug && rightDug && !leftDug)
        {
            return tiles[5];
        }
        else if (upDug && downDug && rightDug && leftDug)
        {
            return tiles[6];
        }
        else if (upDug && downDug && !rightDug && leftDug)
        {
            return tiles[7];
        }
        else if (upDug && downDug && !rightDug && !leftDug)
        {
            return tiles[8];
        }
        else if (upDug && !downDug && rightDug && !leftDug)
        {
            return tiles[9];
        }
        else if (upDug && !downDug && rightDug && leftDug)
        {
            return tiles[10];
        }
        else if (upDug && !downDug && !rightDug && leftDug)
        {
            return tiles[11];
        }
        else if (upDug && !downDug && !rightDug && !leftDug)
        {
            return tiles[12];
        }
        else if (!upDug && !downDug && rightDug && !leftDug)
        {
            return tiles[13];
        }
        else if (!upDug && !downDug && rightDug && leftDug)
        {
            return tiles[14];
        }
        else if (!upDug && !downDug && !rightDug && leftDug)
        {
            return tiles[15];
        }
        return null;
    }

    private void DisplayGridPropertyDetails()
    {
        if (gridPropertyDictionary == null) return;
        foreach (var item in gridPropertyDictionary)
        {
            GridPropertyDetails gridPropertyDetails = item.Value;
            DisplayDugGroud(gridPropertyDetails);
            DisplayWaterGroud(gridPropertyDetails);
            DisplayPlantedCrop(gridPropertyDetails);
        }
    }

    public CropDetails GetCropDetails(GridPropertyDetails gridPropertyDetails)
    {
        if (gridPropertyDetails != null && gridPropertyDetails.seedItemCode > -1)
        {
            return so_CropDetailsList.GetCropDetails(gridPropertyDetails.seedItemCode);
        }
        else
        {
            return null;
        }
    }

    public void DisplayPlantedCrop(GridPropertyDetails gridPropertyDetails)
    {
        if (gridPropertyDetails.seedItemCode > -1)
        {
            CropDetails cropDetails = so_CropDetailsList.GetCropDetails(gridPropertyDetails.seedItemCode);
            GameObject cropPrefab;
            int growthStages = cropDetails.growthDays.Length;
            int currentGrowthStage = 0;
            int daysCounter = cropDetails.totalGrowthDays;
            //找到当前生长期
            for (int i = growthStages - 1; i > 0; i--)
            {
                if (daysCounter < gridPropertyDetails.growthDays)
                {
                    currentGrowthStage = i;
                    break;
                }

                daysCounter -= cropDetails.growthDays[i];
            }

            cropPrefab = cropDetails.growthPrefab[currentGrowthStage];
            Sprite growthSprite = cropDetails.growthSprite[currentGrowthStage];
            Vector3 worldPosition = plainLayer.CellToWorld(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY, 0));
            worldPosition = new Vector3(worldPosition.x + GameSetting.gridCellSize / 2, worldPosition.y, worldPosition.z);
            GameObject cropInstance = Instantiate(cropPrefab, worldPosition, Quaternion.identity);

            cropInstance.GetComponentInChildren<SpriteRenderer>().sprite = growthSprite;
            cropInstance.transform.SetParent(cropParentTransform);
            cropInstance.GetComponent<Crop>().cropGridPosition = new Vector2Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY);
        }
    }

    private bool IsGridDug(int gridX, int gridY)
    {
        GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (gridPropertyDetails == null)
        {
            return false;
        }
        else if (gridPropertyDetails.daysSinceDug > -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsGridWatered(int gridX, int gridY)
    {
        GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(gridX, gridY);
        if (gridPropertyDetails == null)
        {
            return false;
        }
        return (gridPropertyDetails.daysSinceWatered > -1);
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
            sceneSave.boolDictionary = new Dictionary<string, bool>();
            sceneSave.boolDictionary.Add("isFirstTimeSceneLoaded", true);
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

    public void SetGridPropertyDetails(int x, int y, GridPropertyDetails gridPropertyDetails)
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

    public GridPropertyDetails GetGridPropertyDetails(Vector2Int pos)
    {
        return GetGridPropertyDetails(pos.x, pos.y, gridPropertyDictionary);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.gridPropertyDetailsDictionary != null)
            {
                gridPropertyDictionary = sceneSave.gridPropertyDetailsDictionary;
            }

            if (sceneSave.boolDictionary != null && sceneSave.boolDictionary.TryGetValue("isFirstTimeSceneLoaded", out bool storedIsFirstTimeSceneLoaded))
            {
                isFirstTimeSceneLoaded = storedIsFirstTimeSceneLoaded;
            }
            if (isFirstTimeSceneLoaded)
            {
                EventCenter.Instance.Trigger(EventEnum.INSTANTIATE_CROP_PREFAB.ToString());
                isFirstTimeSceneLoaded = false;
            }

            if (gridPropertyDictionary.Count > 0)
            {
                UpdateAllDetails();
            }
        }
    }

    private void UpdateAllDetails()
    {
        //ClearDisplayGridPropertyDetails();
        //DisplayGridPropertyDetails();
    }

    public void ISaveableStoreScene(string sceneName)
    {
        GameObjectSave.sceneData.Remove(sceneName);
        SceneSave sceneSave = new SceneSave();
        sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;
        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }

    private void OnAdvanceDay(GameTime time)
    {
        foreach (SO_GridProperties so_gridProperties in so_gridPropertiesArray)
        {
            if (GameObjectSave.sceneData.TryGetValue(so_gridProperties.sceneName.ToString(), out SceneSave sceneSave))
            {
                if (sceneSave.gridPropertyDetailsDictionary != null)
                {
                    for (int i = sceneSave.gridPropertyDetailsDictionary.Count - 1; i >= 0; i--)
                    {
                        KeyValuePair<string, GridPropertyDetails> item = sceneSave.gridPropertyDetailsDictionary.ElementAt(i);

                        GridPropertyDetails gridPropertyDetails = item.Value;

                        if (gridPropertyDetails.growthDays > -1)
                        {
                            gridPropertyDetails.growthDays += 1;
                        }

                        if (gridPropertyDetails.daysSinceWatered > -1)
                        {
                            gridPropertyDetails.daysSinceWatered = -1;
                        }

                        SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails, sceneSave.gridPropertyDetailsDictionary);
                    }
                }
            }
            UpdateAllDetails();
        }
    }

    public GameObjectSave ISaveableSave()
    {
        ISaveableStoreScene(SceneManager.GetActiveScene().name);
        return GameObjectSave;
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            GameObjectSave = gameObjectSave;
            ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }
}
