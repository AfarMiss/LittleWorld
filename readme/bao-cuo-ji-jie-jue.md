# 报错及解决

## Destroying assets is not permitted to avoid data loss.

该报错是试图使用GameObject.Destroy()方法删除一个赋值为预设的变量，预设不允许被删除，否则会造成数据丢失，可以删除用预设初始化后的实例，即使这个实例被赋值给一个成员变量。
