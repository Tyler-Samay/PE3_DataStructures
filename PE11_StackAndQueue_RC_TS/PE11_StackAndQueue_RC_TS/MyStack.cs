using System;
using System.Collections.Generic;
using System.Text;

namespace PE11_StackAndQueue_RC_TS
{
    class MyStack<T> : IStack<T>
    {
        //Fields
        List<T> items = new List<T>();

        //Properties
        //Count Property
        public int Count
        {
            get { return items.Count; }
        }
        //IsEmpty Property
        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }

        //Methods
        //Peek Method
        public T Peek()
        {
            //Check if list is empty
            if (IsEmpty)
            {
                return default(T);
            }
            //Returns end of list
            return items[Count - 1];
        }
        //Push Method(Adds Item to back of list)
        public void Push(T item)
        {
            items.Add(item);
        }
        //Pop Method
        public T Pop()
        {
            //Check if list is empty
            if (IsEmpty)
            {
                return default(T);
            }
            //Returns and removes end of list
            else
            {
                T temp;
                temp = Peek();
                items.RemoveAt(Count - 1);
                return temp;
            }

        }
    }
}
