# Canvas

## canvas概述

如果canvas中内嵌了canvas，那么内嵌的canvas会继承外部canvas的设置。所有UI元素都必须是某一个Canvas的子物体。

一个场景中，可以有多个Canvas。

## canvas的三种渲染模式

### Screen Space-Overlay

默认设置，UI覆盖在场景最前。UI会自动填充场景，并且会在场景设置（尺寸）变化时自动变化大小。

使用RectTransform组件，且该组件内容无法编辑。Canvas会在RectTransform组件中设置参数以自动适应场景。

pixelPerfect选项可以使UI元素更清晰，但是如果Canvas中有很多旋转或缩放，或者有很多动态位置和缩放的元素，不勾选此选项可以令这些变化更加顺滑。

### Screen Space-Camera

使用RectTransform组件，需要指定特定的渲染相机，（可以是场景中的任意相机，如果不指定，会使用Screen Space-Overlay当中设置的相机），并会自动填充指定相机的ViewPort（当前canvas会出现在该相机的截头椎体中），可以改变Plane Distance来确定UI渲染平面在相机中的远近，并且该值需要在相机的Near和Far之间。

当指定相机的ViewPort Rect设置变化时，Canvas会自动改变大小来适应。距离相机更近的物体整体都会在UI前方。

### World Space

使用Transform组件，在场景中定义一个平面，并像绘制其他物体一样绘制UI。

EventCamera：确定使用哪一个相机检测事件（如鼠标点击事件等），一般情况下，使用渲染场景的相机。

## 相机API参考

ScreenPointToRay会将屏幕上的点投影成射线，而ScreenToWorldPoint是将屏幕上的点投影到制定的相机平面上（具体平面在参数上有所体现），目前“投影到具体layer层的交点”这个需求采用前者去做，因为后者仅仅是名字和这个需求有点关系，实际上一点关系都没有。

## 如何UI预制体打开时不以默认Environment作为父节点？

如果UI预制体中没有Canvas组件或没有正确设置Canvas的RenderMode，那么该预制体会以一个默认的Environment节点作为父节点，如下图所示：

<figure><img src="../../.gitbook/assets/image (8).png" alt=""><figcaption></figcaption></figure>

如要去掉这个默认的父节点，需要点击一下预制体（不要进入预制体预览模式），在Inspector面板中修改预制体根节点下的Canvas组件，将其中的Render Mode修改为Screen Space-Camera或者Screen Space-Overlay。

## 参考资料

1. Canvas [https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html)
2. Canvas介绍 [https://www.youtube.com/watch?v=OD-p1eMsyrU](https://www.youtube.com/watch?v=OD-p1eMsyrU)
