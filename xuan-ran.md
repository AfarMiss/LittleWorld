# 渲染

Graphics->Scriptable Render Pipeline Settings可以修改渲染管线。

### 一、Camera Depth

相机组件上设置的相机深度，深度越大越靠后渲染。

### 二、透明、不透明物体分隔

RenderQueue 2500是透明与不透明的分水岭。

同一个相机下

Renderqueue小于2500的物体 始终在 Renderqueue大于2500之前绘制。

### 三、Sorting Layer

1. 物体的SortingLayer。 根据 Project Setting - Tags & Layers 中的顺序，越靠上的SortingLayer 越先渲染。
2. 物体的OrderInLayer。 数字越小越先渲染。
3. 物体距离摄像机的距离。 越远的越先渲染。

在Tags & Layers设置中可见

如果Camera相同，那接下来就看Sorting Layers，越低越早绘制。

Order In Layer 越小越早绘制。

Sorting Layers是通过Renderer的sortingLayerName属性设置的。

全局Soring Layers在Edit->ProjectSettings->Tags\&Layers中设置

\


<figure><img src="https://pic2.zhimg.com/80/v2-9b32c026dbd3d92d87881c0a288e80bd_1440w.webp" alt=""><figcaption></figcaption></figure>

\


可以通过代码设置render.sortingLayerName=”Effect”运行时设置物体的sortinglayer，如果在粒子系统中看，可以看到Render项的Sorting Layers下拉表单中会列出所有的Sorting Layers的名字

### 四、Order In Layer

相对于Sorting Layer的子排序，用这个值做比较时只有都在同一层时才有效。

soringOrder也是Render的一个属性，这个order是设置一个数字，数字越大，越在上面显示。

<figure><img src="https://pic2.zhimg.com/80/v2-2729938e3a91d74a551eb6c9ac17809d_1440w.webp" alt=""><figcaption></figcaption></figure>

\


### 五、RenderQueue

Shader中对Tags设置的“Queue”。

RenderQueue 2500是透明与不透明的分水岭。优先绘制不透明物体，再绘制_透明_物体。 通过RenderQueue来判断。小于等于_2500_的是不透明物体，大于的是_透明_物体。

如果上述几项都相同，那就要看renderQueue了，renderQueure是Material的一个属性，其实就是Shader中的renderQueue，这个也是一个int属性，数值越小，越靠前渲染。

\


<figure><img src="https://pic4.zhimg.com/80/v2-9f4a2677d8d1baed9861d6473cd5816b_1440w.webp" alt=""><figcaption></figcaption></figure>

Unity5以后，每个材质中都可以设置renderq参数。

<figure><img src="https://pic4.zhimg.com/80/v2-b2ea1628f35eeba6cdb7676b038046ab_1440w.webp" alt=""><figcaption></figcaption></figure>

\


### 六、深度排序。按照包围盒的深度进行排序

不透明物体由近到远排序优先

透明物体由远到近排序优先

按照包围盒的中心点的深度进行排序。

<figure><img src="https://pic1.zhimg.com/80/v2-a84d29e55691ea9918dc36d310cf8f2c_1440w.webp" alt=""><figcaption></figcaption></figure>

### 深度补间

ZBias，当两个包围盒中心点深度值相同或者很近的物体在一起时，排序有可能出错（不一定哪个在前）所以对于这个点的z值可以进行微调。（修改物体的轮廓或移动位置。。。）

\


### 一图总结：

<figure><img src="https://pic1.zhimg.com/80/v2-66ae7f08336ff2580e4dcc32b8877f34_1440w.webp" alt=""><figcaption></figcaption></figure>

### 常规方案

### 明确分层：

例如UI上的半透明（特效、面片）始终在3D场景之上，则一般分多个相机来绘制。

大多适用于有明确分层的游戏。例如横版游戏，明确近景远景

大片填充率的物件，例如地形，天空等，一般为提高深度命中，都会选择在延后批次绘制。

Draw character before the terrain.

### UGUI方案

* 同一个canvas，使用Hierarchy的顺序
* 不同的canvas之间使用sort order来排序

\


### NGUI

不同的pannel按照depth数值排序，同一个pannel中的结点按照深度排序。

\


### 其他排序手段

OIT

也没有太适合的移动解决方案。。。

Unity2018后：

可编程渲染管线——LWRP轻量级渲染管线。可以自定义管线控制排序。。。

三角形排序：

主流引擎都不支持，可使用的场景较少，限制较多。曾在Unity引擎中增加了三角形重心快速排序，效率也不高。。。

参考资料

1.[https://zhuanlan.zhihu.com/p/55762351](https://zhuanlan.zhihu.com/p/55762351)
