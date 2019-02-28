using System;
using System.Collections.Generic;

namespace Lesson4
{ // реализация очереди при помощи стеков
    class QueueOnStack<T>
    {
        Stack<T> s1 = new Stack<T>();
        Stack<T> s2 = new Stack<T>();
        public int Count { get { return s1.Count + s2.Count; } }

        public void Enqueue(T item)
        {
            s1.Push(item);
        }

        public T Dequeue()
        {
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
            }
            return s2.Pop();
        }

        public T Peek
        {
            get
            {
                if (s2.Count == 0)
                {
                    while (s1.Count != 0)
                    {
                        s2.Push(s1.Pop());
                    }
                }
                return s2.Peek();
            }
        }

    }
}
