using System;

namespace Expr10
{
    class Program
    {
        static void Main(string[] args)
        {
            //задача Expr10 с семинара
            //автор Чегодаев Дима. курс 1, группа 11-808
            
            /*находим сумму последоват-и с разн 3,
            * сумму послед-и с разн 5, 
            * вычитаем сумму элем, входящих
            * в обе последовательности (кратные 15)
            */
            int lastIndex = 999 / 3;
            int sum3 = (3 + 999)* lastIndex / 2;
            lastIndex = 999 / 5;
            int sum5 = (5 + 995)* lastIndex / 2;
            lastIndex = 999 / 15;
            int sum15 = (15 + lastIndex * 15)* lastIndex / 2 ;
            Console.WriteLine(sum3 + sum5 - sum15);

            /* проверка
            int sum = 0;
            for (int i=3; i<1000; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum); */
        }
    }
}
