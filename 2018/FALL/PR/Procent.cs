using System;

namespace Procents
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate(Console.ReadLine());
        }

        public static double Calculate(string userInput)
        {
            //считываем данные, введенные пользователем
             
            int index1 = userInput.IndexOf(' ');
            int index2 = userInput.IndexOf(' ');
            double sum = double.Parse(userInput.Substring(0, index1));
            double proc = double.Parse(userInput.Substring(index1, index2 - 1));
            int month = int.Parse(userInput.Substring(index2, userInput.Length - 1));
            // запускаем рекурсию от начальных значений
            return SumOfDeposite(sum, proc, month);
        }

        public static double SumOfDeposite (double sum, double proc, int month)
        {
            /* так как запрещены циклы,
             * придется вести подсчет при помощи рекурсии
             */
            if (month == 0)
            {
                return sum;
            }
            else
            {
               return SumOfDeposite(sum + sum * proc / 12, proc, month - 1);
            }
        }
    }
}
