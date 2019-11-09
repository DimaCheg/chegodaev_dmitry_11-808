using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    class Fibonacci
    {
        public static long GetMember(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            long a = 0;
            long b = 1;
            for (int i = 2; i < n; i++)
            {
                long c = a + b;
                a = b;
                b = c;
            }
            return b;
        }
    }
}
