# Input System

InputAction中的IsPressed()判断Button或者别的什么控制器是否"按下".而IsInProgress()则是用来判断一个过程性按键(例如[SlowTapInteraction](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/api/UnityEngine.InputSystem.Interactions.SlowTapInteraction.html))是否已经按下或者正在被按.

## started,canceled,performed之间的联系？

可以通过“双击”这个事件来解释三者之间的联系。

```
    InputManager.Instance.myController.GlobalInput.DoubleClick.started += (callbackContext) =>
    {
        Debug.Log("double Click started!");
    };

    InputManager.Instance.myController.GlobalInput.DoubleClick.canceled += (callbackContext) =>
    {
        Debug.Log("double Click canceled!");
    };

    InputManager.Instance.myController.GlobalInput.DoubleClick.performed += (callbackContext) =>
    {
        Debug.Log("double Click performed!");
    };
```

started在第一次鼠标点击就被调用，如果长按鼠标这个事件会一直被调用。canceled在鼠标间隔超过“双击”满足条件之后调用，而performed在“双击”事件完成时被调用。

## InputActions

### Action Maps

### Actions

#### binding

可以使用Listen选项直接监听&#x20;

### Properties

#### ActionType

**Value** 连续数值，同一时刻只监听一个输入设备的输入。

**Button** 按键

**Pass Through** 按键系统决定的一系列输入数值，能够同时监听多个设备的输入。



#### Interactions

选择performed完成的种类，比如hold。



#### Processors

选择数值处理方式

**Invert**

举例来说，原本“按下空格跳跃”这个事件中，Started事件接收到的value是1，canceled接收到的value是0.但添加了Invert\[反转] Processor之后，Started接收到的value变成了-1，canceled仍然是0.

**Normalize Vector 2**

可以将输入转换成模为1的输入。

## Player Input

顾名思义，PlayerInput组件是官方提供的放在玩家身上的按键控制组件。

可以通过Create Actions来直接创建一个默认的玩家Action，包含基本人物的移动，查看与开火，以及UI的点击等等。&#x20;

使用SwitchCurrentActionMap切换ActionMap，与之相对的是如果不用这个组件，那么切换输入需要使用对应ActionMap/Action的Enable()/Disable()。

### Behaviour

#### Invoke Unity Events

使用Unity事件，只会在指定的Action处触发。

#### Invoke C Sharp Events

使用C#事件，示例代码见参考2 12:23处，会因任意ActionMap的任意Action触发而触发。

```
private PlayerInput playerInput;

private void Awake(){
    playerInput=GetComponent<PlayerInput>();
    playerInput.onActionTriggered+=PlayerInput_onActionTriggered;
}

private void PlayerInput_onActionTriggered(InputAction.CallbackContext context){
    Debug.Log(context);
}
```

## On-Screen Stick

按键摇杆模拟。

## On-Screen Button

按键按钮模拟

## Input Debugger

位置：Windows->Analysis->Input Debugger. &#x20;

## InputAction.CallbackContext

### performed

按键是否已经被执行。

## 使用自动生成的C#类

该类想要按键生效，需要Enable()。

## 持续性输入

针对移动这种持续性输入，可以在Update中读取CallbackContext.ReadValue的值，然后根据值来做一些持续性动作，而不必要使用performed；也可以使用started方法。

## 参考资料

1. 官方输入系统教程 [https://www.cg.com.tw/UnityInputSystem](https://www.cg.com.tw/UnityInputSystem/)
2. CodeMonkey的New Input System Package介绍 [https://www.youtube.com/watch?v=Yjee\_e4fICc\&t=1430s](https://www.youtube.com/watch?v=Yjee\_e4fICc\&t=1430s)
