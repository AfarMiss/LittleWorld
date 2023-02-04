# Animator

使用Animator组件来给你场景中的某个游戏对象挂载Animation。

## Animator.StringToHash

此方法将Animator参数的字符串名转换成Hash值。

## Animation中SetBool和SetTrigger的区别 <a href="#articlecontentid" id="articlecontentid"></a>

SetBool通常代表对象的一种状态，比如跳跃、跑步等，可以通过GetBool来判断现在是否在这个状态中；而SetTrigger代表当时那一下触发的动画，比如攻击、受伤、死亡等，触发了它们的条件则进行播放。

比较概念性，通常情况下都可以使用，区别不大。

## Animator Event

Animation Clip在动画机中可以添加事件，添加后在Animator同一节点上添加脚本，实现同名函数可以实现对事件的监听。

## 参考资料

1.CSDN [https://blog.csdn.net/Cleve\_baby/article/details/119037731](https://blog.csdn.net/Cleve\_baby/article/details/119037731)
