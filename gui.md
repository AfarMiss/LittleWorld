---
description: >-
  Unity 的 IMGUI 控件使用一个名为 OnGUI() 的特殊函数。只要启用包含脚本，就会在每帧调用 OnGUI() 函数，就像 Update()
  函数一样。
---

# GUI

## 声明 GUI 控件时，需要三段关键信息：

**Type** (**Position**, **Content**)

可以看到，此结构是一个带有两个参数的函数。我们现在将探讨此结构的细节。

#### Type

**Type** 是指 **Control Type（控件类型）\_\_；通过调用 Unity 的** [**GUI 类**](https://docs.unity3d.com/cn/2021.1/ScriptReference/GUI.html)**或** [**GUILayout 类**](https://docs.unity3d.com/cn/2021.1/ScriptReference/GUILayout.html)**中的函数来声明该类型（在本指南的**[**布局模式**](https://docs.unity3d.com/cn/2021.1/Manual/gui-Layout.html)**部分对此进行了详细讨论）。例如，\_\_GUI.Label()** 将创建非交互式标签。本指南稍后的[控件](https://docs.unity3d.com/cn/2021.1/Manual/gui-Controls.html)部分将介绍所有不同的控件类型。

#### Position

**Position** 是所有 **GUI** 控件函数中的第一个参数。此参数本身随附一个 **Rect()** 函数。**Rect()** 定义四个属性：\_\_最左侧位置**、**最顶部位置**、**总宽度**、**总高度**。所有这些值都以\_\_整数\_\_提供，对应于像素值。所有 UnityGUI 控件均在\_\_屏幕空间 (Screen Space)** 中工作，此空间表示已发布的播放器的分辨率（以像素为单位）。

控件种类

Button,InputField,label,repeatButton,TextArea,Toggle,ToolBar,SelectionGrid,HorizontalSlider,VerticalSlider,HorizontalScrollBar,VerticalScrollBar,ScrollView,Window

## 参考资料

1. IMGUI基础知识 [https://docs.unity3d.com/cn/2021.1/Manual/gui-Basics.html](https://docs.unity3d.com/cn/2021.1/Manual/gui-Basics.html)
