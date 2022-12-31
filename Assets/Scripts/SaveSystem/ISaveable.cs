using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    /// <summary>
    /// 存储ID
    /// </summary>
    string ISaveableUniqueID { get; set; }
    /// <summary>
    /// 存储信息
    /// </summary>
    GameObjectSave GameObjectSave { get; set; }
    /// <summary>
    /// 注册存储
    /// </summary>
    void ISaveableRegister();
    /// <summary>
    /// 取消注册存储
    /// </summary>
    void ISaveableDeregister();
    /// <summary>
    /// 存储场景
    /// </summary>
    /// <param name="sceneName"></param>
    void ISaveableStoreScene(string sceneName);
    /// <summary>
    /// 恢复场景
    /// </summary>
    /// <param name="sceneName"></param>
    void ISaveableRestoreScene(string sceneName);
    /// <summary>
    /// 存档存储
    /// </summary>
    /// <returns></returns>
    GameObjectSave ISaveableSave();
    /// <summary>
    /// 存档加载
    /// </summary>
    /// <param name="gameSave"></param>
    void ISaveableLoad(GameSave gameSave);
}
