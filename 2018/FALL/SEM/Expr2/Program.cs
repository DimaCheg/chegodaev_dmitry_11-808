using System;

namespace Expr2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int a1 = number / 100;
            int a2 = number % 100 - number % 10;
            int a3 = number % 10;
            number = a3 * 100 + a2 + a1;
            Console.WriteLine(number);
        }
    }
}
