# Rimworld反编译源码阅读小记

Rimworld的窗口是如何实现的

所有的窗口继承抽象类Window

关于人物行为的窗口创建集中在ChoicesAtFor方法中。
