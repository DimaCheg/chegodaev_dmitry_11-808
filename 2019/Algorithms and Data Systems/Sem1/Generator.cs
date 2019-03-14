using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Generator
    {
        public Data GetData()
        {
            Random rnd = new Random();
            var result = new Data();
            var size = 100;
            for (int i = 0; i < 50; i++)
            {
                var intArray = new long[size];
                var intList = new LinkedList<long>();
                //var stringArray = new string[size];
                //var stringList = new LinkedList<string>();
                //var first = new Node();
                //var node = first;
                //создание массивов и листов
                for (int j = 0; j < size; j++)
                {
                    var number = rnd.Next(int.MinValue, int.MaxValue);
                    intArray[j] = number;
                    intList.AddLast(number);
                    //node.value = number;
                    //node.next = new Node();
                    //node = node.next;
                    //stringArray[j] = RandomString(rnd, rnd.Next(100));
                    //stringList.AddLast(RandomString(rnd, rnd.Next(100)));
                }
                intArray[0] = int.MaxValue;
                intList.AddFirst(int.MaxValue);
                //stringArray[0] = new string('z', 100);
                //stringList.AddLast(new string('a', 100));

                result.intAr[i] = intArray;
                result.intList[i] = intList;
                //result.nodeAr[i] = first;
                //result.strAr[i] = stringArray;
                //result.strList[i] = stringList;
                size += 200;
            }
            return result;
        }

        public string RandomString(Random rnd, int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }

    class Data
    {
        public int count = 50;
        //public Node[] nodeAr = new Node[50];
        public long[][] intAr = new long[50][];
        public string[][] strAr = new string[50][];
        public LinkedList<long>[] intList = new LinkedList<long>[50];
        public LinkedList<string>[] strList = new LinkedList<string>[50];
    }
}
