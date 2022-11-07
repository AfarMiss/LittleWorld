# 对象池

对象池是一种对象复用模式。

Unity中给予了ObjectPool作为对象池类进行使用，除此之外，还有LinkedPool等多种对象池供使用。

Unity的自动化内存管理系统采用的是Boehm垃圾回收器，每当进行垃圾回收时，会停止运行程序代码，并且它只会在垃圾回收器完成所有工作后，才恢复正常的执行。可能会导致游戏延迟执行，持续时间一毫秒到几百毫秒不等。

实践过程中有问题需要日后进一步明确：

为什么FixedUpdate里调用创建方法会导致游戏表现极其卡顿，而在Update中调用就不会出现这样的情况？

## API

createFunc:对象实例化实现；

actionOnGet:出池回调；

actionOnRelease:进池回调；

actionOnDestroy:销毁回调；

collectionCheck:检查集合，对象进池前，会先检查是否在池中；

defaultCapacity:默认容量;

maxSize:池大小的最大值，超出这数值，进池的对象直接销毁;&#x20;

## 参考资料

1. 对象池介绍 [https://www.bilibili.com/read/cv10921967?from=search](https://www.bilibili.com/read/cv10921967?from=search)
