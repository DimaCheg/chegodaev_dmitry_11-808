using System;

namespace Expr12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("введите высоту h: ");
            int h = int.Parse(Console.ReadLine());
            Console.Write("введите время t: ");
            int t = int.Parse(Console.ReadLine());
            Console.Write("максимальная скорость подъёма v: ");
            int v = int.Parse(Console.ReadLine());
            Console.Write("максимальная комфортная скорость подъёма x: ");
            int x = int.Parse(Console.ReadLine());
            
            //минимальное и максимальное время с заложенными ушами
            int min, max;
            if (x * t >= h)
            {
                min = t;
                max = t;
            }
            else
            {
                min = (h - t * x) / (v - x);
                max = t;
            }
            Console.WriteLine(min + " " + max);
        }
        
    }
}
