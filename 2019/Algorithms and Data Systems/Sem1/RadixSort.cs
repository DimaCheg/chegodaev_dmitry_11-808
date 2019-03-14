using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{// сортировка чисел по возрастанию. LSD
    class Sort
    {
        public long[] RadixSort(long[] data, int length)
        {
            var pocket = new List<long>[10];
            for (int i = 0; i < 10; i++)
                pocket[i] = new List<long>();
            var m = 1; ;
            // проход по всем цифрам (от меньшего к большему разряду)
            for (int j = 0; j < length; j++)
            {
                foreach (var list in pocket)
                    list.Clear();
                foreach (var item in data)
                { // j-й справа символ
                    pocket[(Math.Abs(item) / m) % 10].Add(item);
                }
                int i = 0;
                foreach (var list in pocket)
                {
                    foreach (var number in list)
                    {
                        data[i] = number;
                        i++;
                    }
                }
                m *= 10;
            }
            //отделить положительные от отрицательных
            var temp = new LinkedList<long>();
            foreach (var item in data)
            {
                if (item < 0)
                    temp.AddFirst(item);
                else
                    temp.AddLast(item);
            }
            int k = 0;
            foreach (var item in temp)
            {
                data[k] = item;
                k++;
            }
            return data;
        }

        /// <summary>
        /// сортирует по возрастанию связный список целых чисел.
        /// </summary>
        /// <param name="data">входные данные</param>
        /// <param name="length">максимальное количество разрядов (цифр) в числе</param>
        public LinkedList<long> RadixSort(LinkedList<long> data, int length)
        {
            var pocket = new List<long>[10];
            for (int i = 0; i < 10; i++)
                pocket[i] = new List<long>();
            var m = 1;
            // проход по всем цифрам (от меньшего к большему разряду)
            for (int j = 0; j < length; j++)
            {
                foreach (var list in pocket)
                    list.Clear();
                foreach (var item in data)
                { // j-й справа символ
                    pocket[(Math.Abs(item) / m) % 10].Add(item);
                }
                data.Clear();
                foreach (var list in pocket)
                {
                    foreach (var number in list)
                        data.AddLast(number);
                }
                m *= 10;
            }
            var result = new LinkedList<long>();
            foreach (var item in data)
            {
                if (item < 0)
                    result.AddFirst(item);
                else
                    result.AddLast(item);
            }
            return result;
        }
        
        public string[] RadixSort(string[] data, int length)
        {
            var pocket = new SortedDictionary<char, List<string>>();
            var nullSymbol = new List<string>(); //здесь будут храниться строки,длина которых меньше максимальной

            for (int j = length - 1; j > -1; j--)
            {
                foreach (var item in data)
                {
                    if (item.Length > j)
                    {
                        char symbol = item[j];
                        if (pocket.ContainsKey(symbol))
                            pocket[symbol].Add(item);
                        else
                        {
                            pocket.Add(symbol, new List<string>());
                            pocket[symbol].Add(item);
                        }
                    }
                    else
                        nullSymbol.Add(item);
                }
                int i = 0;
                foreach (var item in nullSymbol)
                {
                    data[i] = item;
                    i++;
                }
                nullSymbol.Clear();
                foreach (var pair in pocket)
                {
                    foreach (var str in pair.Value)
                    {
                        data[i] = str;
                        i++;
                    }
                    pair.Value.Clear();
                }
            }
            return data;
        }

        /// <summary>
        /// сортирует по возрастанию связный список строк.
        /// </summary>
        /// <param name="data">входные данные</param>
        /// <param name="length">максимальное количество разрядов (знаков) в строке</param>
        public LinkedList<string> RadixSort(LinkedList<string> data, int length)
        {
            var pocket = new SortedDictionary<char, List<string>>();
            var nullSymbol = new List<string>(); //здесь будут храниться строки,длина которых меньше максимальной

            for (int j = length - 1; j > -1; j--)
            {
                foreach (var item in data)
                {
                    if (item.Length > j)
                    {
                        char symbol = item[j];
                        if (pocket.ContainsKey(symbol))
                            pocket[symbol].Add(item);
                        else
                        {
                            pocket.Add(symbol, new List<string>());
                            pocket[symbol].Add(item);
                        }
                    }
                    else
                        nullSymbol.Add(item);
                }
                data.Clear();
                foreach (var item in nullSymbol)
                    data.AddLast(item);
                nullSymbol.Clear();
                foreach (var pair in pocket)
                {
                    foreach (var str in pair.Value)
                        data.AddLast(str);
                    pair.Value.Clear();
                }
            }
            return data;
        }

        public Node RadixSort2(Node node, int length)
        {
            int i, m = 1;
            long digit;
            Node temp;
            var first = new Node[19];
            var last = new Node[19];

            for (int j = 0; j < length; j++)
            {
                for (i = 0; i < 19; i++)
                    first[i] = last[i] = null;
                while (node != null)
                {
                    digit = 9 + (node.value / m) % 10;
                    temp = last[digit];
                    if (first[digit] == null)
                        first[digit] = node;
                    else
                        temp.next = node;
                    temp = last[digit] = node;
                    node = node.next;
                    temp.next = null;
                }
                //поиск 1ого непустого кармана
                for (i = 0; i < 19; i++)
                    if (first[i] != null)
                        break;
                node = first[i];
                temp = last[i];
                for (digit = i + 1; digit < 19; digit++)
                    if (first[digit] != null)
                    {
                        temp.next = first[digit];
                        temp = last[digit];
                    }
                m *= 10;
            }
            return node;
        }
    }

    class Node
    {
        public long value;
        public Node next;
        public void Add(long num)
        {
            value = num;
            next = new Node();
        }
    }
}
