using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    public class FareySequence
    {
        public Fraction GetSequence(int n)
        {
            var f1 = new Fraction(1, 1, null);
            var f0 = new Fraction(0, 1, f1);
            for (int i = 2; i <= n; i++)
            {
                var current = f0;
                while (current.Next != null)
                {
                    if (current.Denominator + current.Next.Denominator ==i)
                    {
                        var f = new Fraction(current.Numerator + current.Next.Numerator, i, current.Next);
                        current.Next = f;
                    }
                    current = current.Next;
                }
            }
            return f0;
        }

        public void Print(Fraction item)
        {
            while (item != null)
            {
                Console.WriteLine(item.Numerator + "/" + item.Denominator);
                item = item.Next;
            }
        }
    }

    public class Fraction
    {//все элементы ряда - дроби
        internal int Numerator { get; set; }
        internal int Denominator { get; set; }
        internal Fraction Next { get; set; }

        public Fraction(int numerator, int denominator, Fraction next)
        {
            Numerator = numerator;
            Denominator = denominator;
            Next = next;
        }
    }
}
