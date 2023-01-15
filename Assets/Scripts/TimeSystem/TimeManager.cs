using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>, ISaveable
{
    public GameTime CurGameTime => curGameTime;
    private GameTime curGameTime;

    private float curTickTime;

    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }
    public GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    protected override void Awake()
    {
        base.Awake();
        iSaveableUniqueID = gameObject.GetOrAddComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    public override void Initialize()
    {
        base.Initialize();

        curTickTime = 0;
        curGameTime = new GameTime(6000, 1, 1, 6, 0, 0);
        EventCenter.Instance.Trigger(EventEnum.SECOND_CHANGE.ToString(), curGameTime);
    }

    private void FixedUpdate()
    {
        curTickTime += Time.fixedDeltaTime;
        while (curTickTime - FarmSetting.gameTick > FarmSetting.gameTick)
        {
            curTickTime -= FarmSetting.gameTick;
            curGameTime.AddTick();
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

    public void AdvanceDay()
    {
        curGameTime.AddOneDay();
    }

    public void AdvanceDay(int count)
    {
        for (int i = 0; i < count; i++)
        {
            curGameTime.AddOneDay();
        }
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
        GameObjectSave.sceneData.Remove(FarmSetting.PersistentScene);

        SceneSave sceneSave = new SceneSave();
        sceneSave.gameTime = curGameTime;

        GameObjectSave.sceneData.Add(FarmSetting.PersistentScene, sceneSave);

        return GameObjectSave;
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            if (gameObjectSave != null && gameObjectSave.sceneData.TryGetValue(FarmSetting.PersistentScene, out SceneSave sceneSave))
            {
                curGameTime = sceneSave.gameTime;
            }
        }
    }
}
