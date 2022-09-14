# Canvas

## 如何UI预制体打开时不以默认Environment作为父节点？

如果UI预制体中没有Canvas组件，那么该预制体会以一个默认的Environment节点作为父节点，如下图所示：

<figure><img src="../../.gitbook/assets/image (8).png" alt=""><figcaption></figcaption></figure>

如要去掉这个默认的父节点，需要修改预制体根节点下的Canvas组件，将其中的Render Mode修改为Screen Space-Camera。
