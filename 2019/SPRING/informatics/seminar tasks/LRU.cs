using System;
using System.Collections.Generic;
using System.Text;

namespace LDsem
{
    class LRU<T>
    {
        LinkedList<int> usedKeys = new LinkedList<int>();
        Dictionary<int, T> dictionary = new Dictionary<int, T>();

        public void Add(int key, T value)
        {
            dictionary.Add(key, value);
            //ключ использован (теперь последний в очереди)
            if (usedKeys.Contains(key))
                usedKeys.Remove(key);
            usedKeys.AddLast(key);
        }

        public T Get(int key)
        {
            if (usedKeys.Contains(key))
                usedKeys.Remove(key);
            usedKeys.AddLast(key);
            return dictionary[key];
        }

        public void RemoveLeastRecentlyUsed()
        {
            var key = usedKeys.First.Value;
            dictionary.Remove(key);
            usedKeys.Remove(key);
        }
    }
}
