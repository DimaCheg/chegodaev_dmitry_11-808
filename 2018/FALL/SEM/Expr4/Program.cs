using System;

namespace Expr4
{
    class Program
    {
        static void Main(string[] args)
        {
            // считываем N, X, Y
            Console.WriteLine("Введите число N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число X: ");
            int X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число Y: ");
            int Y = Convert.ToInt32(Console.ReadLine());
            // находим результат 
            int result = (N - 1) / X + (N - 1) / Y - (N - 1) / (X * Y);
            Console.WriteLine(result);
        }
    }
}
