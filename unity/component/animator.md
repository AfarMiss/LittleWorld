# Animator

使用Animator组件来给你场景中的某个游戏对象挂载Animation。

## Animator.StringToHash

此方法将字符串转换成Hash值，如果用该方法将对应字符串的hash值存储下来，那么只需要转换一次。而使用string作为参数调用Animator.SetFloat/SetBool/SetInteger的话，字符串在每次调用时都需要创建。
