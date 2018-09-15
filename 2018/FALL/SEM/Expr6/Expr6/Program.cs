using System;

namespace Expr6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты прямой: ");
            Console.WriteLine("точка 1 X1: ");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("точка 1 У1: ");
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("точка 2 X2: ");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("точка 2 У2: ");
            int y2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите координаты точки: ");
            Console.WriteLine("X0: ");
            int x0 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("У0: ");
            int y0 = Convert.ToInt32(Console.ReadLine());

            decimal distance = Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1);
            distance = distance / (Math.Sqrt((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1)));
            Console.WriteLine(distance);
        }
    }
}
