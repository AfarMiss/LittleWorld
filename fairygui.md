# FairyGUI

## 动态创建UI资源

### 设置适配相关

```
GRoot.inst.SetContentScaleFactor(1365, 768, UIContentScaler.ScreenMatchMode.MatchHeight);
```

### 添加包

```
        UIPackage package = UIPackage.AddPackage("UI/Teach");
```

### 添加依赖包

```
        foreach (var item in package.dependencies)
        {
            UIPackage.AddPackage("UI/" + item["name"]);
        }
```

### 同步加载

```
    GComponent view = UIPackage.CreateObject("Teach", "TeachPanel").asCom;
    GRoot.inst.AddChild(view);
```

### 异步加载

```
    UIPackage.CreateObjectAsync("Teach", "TeachPanel", (obj) =>
    {
        GComponent v = obj.asCom;
        GRoot.inst.AddChild(v);
    });
```

## GComponent常用API

### 位置

x,y,SetPosition

### 宽高

width,height,SetSize

### 轴心点

轴心点是旋转中心点。锚点是UI位置点。

pivotX,pivotY,pivotAsAnchor(设置轴心点是否同时为锚点),SetPivot

### 角度

rotation

### 可见性

visible

### 置灰

grayed

### 缩放

scaleX,scaleY

### 排序层(子对象层级)

sortingOrder

### 点击不穿透

opaque

### 子对象数量

numChildren

### 根据名称获取子对象

GetChild()

### 根据索引获取子对象

SetChildIndex

### 子对象排序规则

childrenRenderOrder，默认升序排列，从小到大依次渲染，序号大的显示在前面。
