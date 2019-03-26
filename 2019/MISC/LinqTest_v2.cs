using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace linq_test
{
    static class Ext
    {// номер 2
        public static IEnumerable<Tuple<T1, T2>> Task2<T1, T2, Titem>
            (this IEnumerable<T1> data1, IEnumerable<T2> data2, Func<T1, T2, bool> f)
        {
            var e1 = data1.GetEnumerator();
            var e2 = data2.GetEnumerator();
            while (e1.MoveNext() || e2.MoveNext())
            {
                if (f(e1.Current, e2.Current))
                    yield return Tuple.Create(e1.Current, e2.Current);
            }
        }
    }
    class LinqTest
    {
        public void Task1(IEnumerable<int> A)
        {// номер 1
            var count = -1;
            var result = A.Select(num =>
            {
                count++;
                if (count % 3 == 0)
                    return 0;
                else if (count % 3 == 1)
                    return num * 2;
                else
                    return num;
            });
            count = -1;
            result = result.Where(num =>
            {
                count++;
                return count % 3 != 0;
            });
        }
    }
}
