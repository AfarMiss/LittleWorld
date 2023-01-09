# Rimworld反编译源码阅读小记

Rimworld的窗口是如何实现的

所有的窗口继承抽象类Window

关于人物行为的窗口创建集中在ChoicesAtFor方法中。

关于地图的绘制是使用Graphics.DrawMesh接口完成的
