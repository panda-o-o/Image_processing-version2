using OpenCvSharp;
using System;
using System.Diagnostics;

namespace Image_processing.Class
{
    public delegate void del_process(ref Mat img,ref Mat mask);
    public class linked_list
    {
        // 定义一个委托链表
        private del_process? List;

        // 添加一个委托到链表中
        public void AddDelegate(del_process newDelegate)
        {
            // 使用 + 运算符将新委托添加到链表的末尾
            List += newDelegate;
        }

        // 从委托链表中删除指定的委托
        public void RemoveDelegate(del_process oldDelegate)
        {
            // 使用 - 运算符将委托从链表中移除
            List -= oldDelegate;
        }

        // 调用委托链表中的所有委托
        public void InvokeDelegates(ref Mat img, ref Mat mask)
        {
            // 遍历委托链表中的每一个委托
            foreach (del_process del in List?.GetInvocationList() ?? Enumerable.Empty<Delegate>())
            {
                try
                {
                    // 执行委托
                    del(ref img, ref mask);
                }
                catch (Exception ex)
                {
                    // 记录异常信息
                    string error = $"在执行{del.Method.Name}时发生错误: \r\n{ex.Message}";
                    MessageBox.Show(error,"提示" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        //移除指定位置的委托
        public void RemoveDelegateAt(int index)
        {
            if (index < 0)
            {
                return;
            }
            // 将委托链表转换为数组
            Delegate[]? delegates = List?.GetInvocationList();

            if (delegates != null && delegates.Length > index)
            {
                // 从数组中删除指定位置的委托
                Delegate removedDelegate = delegates[index];
                delegates = delegates.Where((d, i) => i != index).ToArray();

                // 重新构建委托链表
                List = null;
                foreach (var del in delegates)
                {
                    List += (del_process)del;
                }
            }
        }

        public void InsertDelegateAtPosition(del_process newDelegate, int position)
        {
            if (position < 0)
            {
                throw new ArgumentException("Position must be a non-negative integer", "position");
            }

            // 将链表中的所有委托存储在一个数组中
            var delegateArray = List?.GetInvocationList();

            if (delegateArray == null)
            {
                // 如果链表为空，则直接将新委托添加到链表的末尾
                AddDelegate(newDelegate);
                return;
            }

            if (position > delegateArray.Length)
            {
                throw new ArgumentException("Position is out of range", "position");
            }

            // 创建一个新数组，它的长度比旧数组多1
            var newDelegateArray = new del_process[delegateArray.Length + 1];

            // 将新委托插入到新数组中的指定位置
            for (int i = 0; i < newDelegateArray.Length; i++)
            {
                if (i < position)
                {
                    newDelegateArray[i] = (del_process)delegateArray[i];
                }
                else if (i == position)
                {
                    newDelegateArray[i] = newDelegate;
                }
                else
                {
                    newDelegateArray[i] = (del_process)delegateArray[i - 1];
                }
            }

            // 将新数组中的所有委托重新组合成一个新的委托链表
            List = null;
            foreach (var del in newDelegateArray)
            {
                List += del;
            }
        }
    }
}
