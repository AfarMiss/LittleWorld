# Camera

## UI相机的摆放

## canvas

如果canvas中内嵌了canvas，那么内嵌的canvas会继承外部canvas的设置。

## canvas的三种模式

### Screen Space-Overlay

UI始终在最前

### Screen Space-Camera

距离相机更近的物体整体都会在UI前方

### World Space

在三维空间定义一个平面，并像绘制其他物体一样绘制UI

## 相机API参考

ScreenPointToRay会将屏幕上的点投影成射线，而ScreenToWorldPoint是将屏幕上的点投影到制定的相机平面上（具体平面在参数上有所体现），目前“投影到具体layer层的交点”这个需求采用前者去做，因为后者仅仅是名字和这个需求有点关系，实际上一点关系都没有。

## 参考资料

1. Canvas [https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html)
