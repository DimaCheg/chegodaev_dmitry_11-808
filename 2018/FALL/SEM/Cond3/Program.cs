using System;

namespace Cond3
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * семинарская задача */

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            // найдём первую и вторую половину предыдущего номера
            int prevLeft = (number--) / 1000;
            int prevRight = (number--) % 1000;
            // найдём первую и вторую половину следующего номера
            int nextLeft = (number++) / 1000;
            int nextRight = (number++) % 1000;
            if (SumOfNumeral(prevLeft) == SumOfNumeral(prevRight) || 
                SumOfNumeral(nextLeft) == SumOfNumeral(nextRight))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static int SumOfNumeral (int a)
        {
            //вычисляет сумму цифр числа
            int sum = 0;
            while (a > 0)
            {
                sum += a % 10;
                a /= 10;
            }
            return sum;
        }
    }
}
