# 对象池

对象池是一种对象复用模式。

Unity中给予了ObjectPool作为对象池类进行使用。

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
