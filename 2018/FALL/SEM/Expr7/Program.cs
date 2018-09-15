using System;

namespace Expr7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коэффициенты А и В для уравнения Ах+Ву+С");
            Console.Write("коэф А: ");
            double A = double.Parse(Console.ReadLine());
            Console.Write("Коэф В: ");
            double B = double.Parse(Console.ReadLine());
            Console.WriteLine("параллельный вектор: (" + B + ", " + A * (-1) + ")");
            Console.WriteLine("перпендикулярный вектор: (" + A + ", " + B + ")");
        }
    }
}
