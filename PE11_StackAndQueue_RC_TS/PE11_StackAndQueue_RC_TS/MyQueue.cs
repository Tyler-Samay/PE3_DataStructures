using System;
using System.Collections.Generic;
using System.Text;

namespace PE11_StackAndQueue_RC_TS
{
    class MyQueue<T> : IQueue<T>
    {
        //Fields
        private List<T> items = new List<T>();

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
            //Returns front of list
            else
            {
                return items[0];
            }
        }
        //Enqueue Method(Adds Item to back of list)
        public void Enqueue(T item)
        {
            items.Add(item);
        }
        //Dequeue Method
        public T Dequeue()
        {
            //Check if list is empty
            if (IsEmpty)
            {
                return default(T);
            }
            //Returns and removes front of list
            else
            {
                T temp;
                temp = Peek();
                items.RemoveAt(0);
                return temp;
            }
        }
    }
}
