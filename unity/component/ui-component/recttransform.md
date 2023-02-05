# RectTransform

## RectTransform与Rect

RectTransform内部用一个Rect结构体的变量表示其具体信息。

## RectTransform.sizeDelta和Rect.size

RectTransform.sizeDelta可读可写，Rect.size只可读，不仅如此，Rect.width和Rect.height也只可读。

sizeDelta表示这个RectTransform的大小相对于Anchor之间的距离。

如果Anchor在一起，sizeDelta就和size大小相同。如果Anchor在父对象的四个角角上，则sizeDelta表示该节点自身的矩形与其父对象相比的大小。

RectTransform的Rect起始位置始终是(0,0)，这意味着需要另一个矩形区域表示框选范围。

## 参考资料

1. Rect [https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Rect.html](https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Rect.html)
