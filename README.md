# Calculator


## 计算器逻辑

>两个栈，分别用于存放操作符和数字，遍历计算式，若为数字则压入数字栈，若为操作符，符号栈为空则直接入栈，若非空则与栈顶符号进行比较，若低于或等于栈顶符号，则从数字栈取出两个元素，取栈顶符号进行运算，将结果压入数字栈，重复以上步骤，直至遍历结束

version0.0
> 手搓了两个栈，并实现入栈出栈栈内元素非空的功能，支持根号，支持多项式计算

version1.0
1. 新增Stack类，换掉了手搓的两个栈，使用泛型Stack<object>来支持多种类型
2. 新增了Grade类专门用于返回操作符的优先级和根据输入计算结果
3. 支持阶乘运算

![pic](/images/calcunew.jpg)

