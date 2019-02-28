using System;
using System.Collections.Generic;

namespace Lesson4
{ //реализация стека при помощи очередей
    class StackOnQueue<T>
    {
        Queue<T> q1 = new Queue<T>();
        Queue<T> q2 = new Queue<T>();
        public int Count { get { return q1.Count + q2.Count; } }

        public void Push(T item)
        {
            q1.Enqueue(item);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (q1.Count == 0)
            {
                while (q2.Count > 1)
                {
                    q1.Enqueue(q2.Dequeue());
                }
                return q2.Dequeue();
            }
            else
            {
                while (q1.Count > 1)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                return q1.Dequeue();
            }
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (q1.Count == 0)
            {
                while (q2.Count > 1)
                {
                    q1.Enqueue(q2.Dequeue());
                }
                return q2.Dequeue();
            }
            else
            {
                while (q1.Count > 1)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                return q1.Peek();
            }
        }

    }
}
