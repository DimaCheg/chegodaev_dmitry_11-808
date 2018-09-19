using System;

namespace Expr11
{
    class Program
    {
        static void Main(string[] args)
        {
            //задача Expr11 с семинара
            //автор Чегодаев Дима. курс 1, группа 11-808

            //считываем время и находим положение стрелок на
            // классических часах
            double hours = double.Parse(Console.ReadLine());
            hours %= 12;
            int minute = int.Parse(Console.ReadLine());
            /*скорость движения стрелок:
             * минутная 6 град/мин
             * часовая 0,5 град/мин
             */
            hours = hours * 30 + minute * 0.5;
            minute = minute * 6;
            double Angle = Math.Abs(hours - minute);
            Console.WriteLine(Angle);
        }
    }
}
