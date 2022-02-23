using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Sorted_List
{
    /// uses interface
    class SortedList : ISortedCollection
    {
        private List<int> list = new List<int>();

        public int Count
        {
            get { return list.Count; }
        }
        public bool IsEmpty
        {
            get
            {
                if (Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// adds the given new data to the collection
        public void Add(int newData)
        {
            // track if data added yet
            bool dataAdded = false;
            // check each int in list
            for (int i = 0; i < list.Count; i++)
            {
                // if int at i is less than the new data
                if (newData < list[i])
                {
                    // insert new data at position i
                    list.Insert(i, newData);
                    // change check to true, breaks loop
                    dataAdded = true;
                    break;
                }
            }
            // if new data not added, add to end
            if (!dataAdded)
            {
                list.Add(newData);
            }
        }

        /// check if list contains given data
        public bool Contains(int data)
        {
            // check each int in list
            foreach (int i in list)
            {
                // if int at index i equals data return true
                if (i == data)
                {
                    return true;
                }
            }
            // if int not found in list return false
            return false;
        }

        /// clears list
        public void Clear()
        {
            list.Clear();
        }

        // prints each item in list
        public void Print()
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }

        /// returns lowest value in list
        ///   or MinValue if the list is empty
        public int Min()
        {
            if (IsEmpty)
            {
                return int.MinValue;
            }
            else
            {
                return list[0];
            }
        }

        /// returns greatest value in list
        ///   or MaxValue if the list is empty
        public int Max()
        {
            if (IsEmpty)
            {
                return int.MaxValue;
            }
            else
            {
                return list[list.Count - 1];
            }
        }
    }
}
