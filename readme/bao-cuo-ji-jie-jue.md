# 报错及解决

## Destroying assets is not permitted to avoid data loss.

该报错是试图使用GameObject.Destroy()方法删除一个赋值为预设的变量，预设不允许被删除，否则会造成数据丢失，可以删除用预设初始化后的实例，即使这个实例被赋值给一个成员变量。

**error: Could not set up a toolchain for Architecture x64. Make sure you have the right build tools installed for il2cpp builds. Details: UnityEngine.GUIUtility:ProcessEvent (int,intptr,bool&)**

用Visual Studio Installer安装Desktop Development With C++

<figure><img src="../.gitbook/assets/image.png" alt=""><figcaption></figcaption></figure>
