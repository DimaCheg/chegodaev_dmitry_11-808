using System;

namespace Expr3
{
    class Program
    {
        static void Main(string[] args)
        {
            int Hours = Convert.ToInt32(Console.ReadLine());
            /*считали текущее время. по условию количество
            часов целое, след-о минутная стрелка "на 12" */
            Hours = Hours % 12;
            int Angle = Hours * 30;
            Console.WriteLine(Angle + "degrees");
        }
    }
}
