using System;

namespace Cond4
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * семинарская задача */

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("введите А: ");
            double A = double.Parse(Console.ReadLine());
            Console.Write("введите B: ");
            double B = double.Parse(Console.ReadLine());
            Console.Write("введите C: ");
            double C = double.Parse(Console.ReadLine());
            Console.Write("введите D: ");
            double D = double.Parse(Console.ReadLine());
            // за начало перечесения берем начало того отрезка,
            // чья координата больше
            double left = Math.Max(A, C);
            // за конец пересечения берем конец того отрезка,
            // чья координата меньше
            double right = Math.Min(B, D);
            // если конец отрезка пересечения лежит 
            // левее, чем начало, то отрезки не пересекаются
            Console.WriteLine(Math.Max(right - left, 0));
        }
    }
}
