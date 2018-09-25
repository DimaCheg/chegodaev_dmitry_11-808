using System;

namespace Cond7
{
    class Program
    {
        static void Main(string[] args)
        {
            /* автор: Чегодаев Дима
             * гр. 11-808
             * семинарская задача Cond7
             */
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            /* (x*n+k*1)/(n+k) <= y 
             * решаем это неравенство, где к - количество необходимых единиц 
             * конечное неравенство k >= n(x-y)/(y-1) */
            if (x <= y)
            {
                Console.WriteLine(0);
            }
            else if (y == 1)
            {
                Console.WriteLine("Impossible");
            }
            else
            {
                double k = n * (x - y) / (y - 1);
                if (k % 1 != 0)
                {
                    k++;
                }
                Console.WriteLine(k);
            }
        }
    }
}
