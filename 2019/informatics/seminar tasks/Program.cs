using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LINQ_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static IEnumerable<string> Task1(IEnumerable<string> data, int l)
        {
            return data
                .TakeWhile(str => str.Length < l)
                .Where(str => char.IsLetter(str[str.Length - 1]))
                .OrderByDescending(str => str.Length)
                .ThenBy(s => s);
        }

        public static IEnumerable<int> Task2(IEnumerable<int> data, int k)
        {
            //все четные числа, с порядковыми номерами не больше К?
            return data
                .Take(k)
                .Where(num => num % 2 == 0)
                .Distinct() // ?
                .Reverse();
        }

        public static IEnumerable<char> Task3(IEnumerable<string> data)
        {
            return data
                .Select(str => str[0]) //строки не пустые по условию
                .Reverse();
        }

        public static IEnumerable<string> Task4(IEnumerable<int> data)
        {
            return data
                .Where(num => num % 2 == 1)
                .Select(num => num.ToString())
                .OrderBy(s => s);
        }
    }
}
