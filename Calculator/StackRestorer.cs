using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    public class StackRestorer
    {
        private Stack<object> stack;
        /// <summary>
        /// 初始化 StackRestorer 类的新实例。
        /// </summary>
        public StackRestorer()
        {
            stack = new Stack<object>();
        }

        /// <summary>
        /// 将指定的数据压入栈中。
        /// </summary>
        /// <param name="data">要压入栈中的数据。</param>
        /// <returns>操作是否成功。</returns>
        public bool Push(object data)
        {
            try
            {
                stack.Push(data);
                return true;
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("内存不足：" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取栈中的元素数量。
        /// </summary>
        /// <returns>栈中的元素数量。</returns>
        public int GetDataCount()
        {
            return stack.Count;
        }

        /// <summary>
        /// 弹出栈顶元素。
        /// </summary>
        /// <returns>被弹出的元素。</returns>
        public object Pop()
        {
            try
            {
                return stack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("栈为空：" + ex.Message);
                return null;
            }
        }

    }
}