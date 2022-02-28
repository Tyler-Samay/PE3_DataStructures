using System;

namespace PE11_StackAndQueue_RC_TS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack Tests
            //Int Stack Test
            MyStack<int> intStack = new MyStack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            intStack.Push(4);
            intStack.Push(5);
            Console.WriteLine("The int stack has {0} items in it.", intStack.Count);
            Console.WriteLine("\tStarting at the top they are: ");
            while (!intStack.IsEmpty)
            {
                Console.WriteLine(intStack.Peek());
                intStack.Pop();
            }
            //String Stack Test
            MyStack<string> stringStack = new MyStack<string>();
            stringStack.Push("a");
            stringStack.Push("b");
            stringStack.Push("c");
            stringStack.Push("d");
            stringStack.Push("e");
            Console.WriteLine("The string stack has {0} items in it.", stringStack.Count);
            Console.WriteLine("\tStarting at the top they are: ");
            while (!stringStack.IsEmpty)
            {
                Console.WriteLine(stringStack.Peek());
                stringStack.Pop();
            }

            //QueueTests
            //Int Queue Test
            MyQueue<int> intQueue = new MyQueue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            intQueue.Enqueue(5);
            Console.WriteLine("The int queue has {0} items in it.", intQueue.Count);
            Console.WriteLine("\tStarting from the front they are: ");
            while (!intQueue.IsEmpty)
            {
                Console.WriteLine(intQueue.Peek());
                intQueue.Dequeue();
            }
            //String Queue Test
            MyQueue<string> stringQueue = new MyQueue<string>();
            stringQueue.Enqueue("a");
            stringQueue.Enqueue("b");
            stringQueue.Enqueue("c");
            stringQueue.Enqueue("d");
            stringQueue.Enqueue("e");
            Console.WriteLine("The string queue has {0} items in it.", stringQueue.Count);
            Console.WriteLine("\tStarting from the front they are: ");
            while (!stringQueue.IsEmpty)
            {
                Console.WriteLine(stringQueue.Peek());
                stringQueue.Dequeue();
            }
        }
    }
}
