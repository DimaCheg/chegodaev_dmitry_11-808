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
            var res = A.Select(num =>
            {
                count++;
                if (count % 3 == 0)
                    return 3;
                else if (count % 3 == 1)
                    return num * 2;
                else
                    return num;
            }).Where(num => num != 3);
            //foreach (var num in res)
            //    Console.WriteLine(num);
        }

        public void Task3(IEnumerable<string> B1, IEnumerable<string> C1,
            IEnumerable<string> D1, IEnumerable<string> E1)
        {// номер 3
            var B = B1.Select(line =>
            {
                var s = line.Split();
                return new
                {
                    article = int.Parse(s[1]),
                    country = s[2]
                };
            });
            var C = C1.Select(line =>
            {
                var s = line.Split();
                return new
                {
                    discount = int.Parse(s[0]),
                    market = s[1],
                    customer = int.Parse(s[2])
                };
            });
            var D = D1.Select(line =>
            {
                var s = line.Split();
                return new
                {
                    price = int.Parse(s[0]),
                    market = s[1],
                    article = int.Parse(s[2])
                };
            });
            var E = E1.Select(line =>
            {
                var s = line.Split();
                return new
                {
                    market = s[0],
                    customer = int.Parse(s[1]),
                    article = int.Parse(s[2])
                };
            });
            //для каждого проданного товара указать страну-производителя,
            // затем цену
            E.Join(B, e => e.article, b => b.article, (e, b) =>
                new { e.article, e.customer, e.market, b.country })
              .Join(D, e => e.article + e.market, d => d.article + d.market,
              (e, d) => new { e.article, e.customer, e.market, e.country, d.price });
              //.GroupJoin(C, e=> e.market + e.customer, c=> c.market + c.customer,
              //(e,d)=>)
        }
    }
}
