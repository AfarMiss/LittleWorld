# 旋转

## 一、Rotate

例：

```
//应用一个围绕 Z 轴旋转 eulerAngles.z 度、围绕 X 轴旋转 eulerAngles.x 度、围绕 Y 轴旋转 eulerAngles.y 度（按此顺序）的旋转。   
 this.transform.Rotate(new Vector3(angleZ, angleX, angleY));
```

## 二、FromToRotation

例：

```
    //enemyPos是敌人位置，transform.position是自身位置，这段代码产生一个从玩家到敌人的旋转角度。
    Vector3 v = enemyPos - transform.position;
    v.z = 0;
    Quaternion rotation = Quaternion.FromToRotation(Vector3.up, v);
    transform.rotation = rotation;
```
