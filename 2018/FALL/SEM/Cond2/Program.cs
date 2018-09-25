using System;

namespace Cond2
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * семинарская задача */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите размеры предметов");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (Math.Max(Math.Min(x, y), Math.Min(z, y)) <= Math.Max(a, b) &&
                Math.Min(Math.Min(x, y), z) <= Math.Min(a, b)) 
            {
                // если среднее измерение бруса меньше максимального измерения отверстия
                // и минимальное измерение бруса меньше минимального измерения отверстия
                Console.WriteLine("пролезет");
            }
            else
            {
                Console.WriteLine("не пролезет");
            }
        }
    }
}
