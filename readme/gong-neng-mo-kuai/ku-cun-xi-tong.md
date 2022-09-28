# 库存系统

## 添加步骤

1. 建立库存枚举。
2. 建立库存Struct，注意Struct要添加\[System.Serializable] 特性。
3. 在事件中心中管理添加物品变动对应事件。
4. 再InventoryManager中管理添加与删除库存，再物品库存变动时触发对应事件。



## 相关接口

AddItem(InventoryLocationEnum location,Item item,Gameobject gameobjectToDestroy)
