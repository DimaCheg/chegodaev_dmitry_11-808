using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WindowsFormsApp1
{
    class Timer
    {
        public Times GetTimes()
        {
            var g = new Generator();
            var data = g.GetData();
            var watch = new Stopwatch();
            var sorter = new Sort();
            var result = new Times();
            for (int i = 0; i < 50; i++)
            {
                watch.Start();
                sorter.RadixSort(data.intAr[i], 10);
                watch.Stop();
                result.intArrayRes[i, 0] = data.intAr[i].GetLength(0);
                result.intArrayRes[i, 1] = watch.ElapsedMilliseconds;

                watch.Restart();
                sorter.RadixSort(data.intList[i], 10);
                watch.Stop();
                result.intListRes[i, 0] = data.intList[i].Count;
                result.intListRes[i, 1] = watch.ElapsedMilliseconds;

                //watch.Restart();
                //sorter.RadixSort2(data.nodeAr[i], 10);
                //watch.Stop();
                //result.nodeRes[i,0]= data.intAr[i].GetLength(0);
                //result.nodeRes[i, 1] = watch.ElapsedMilliseconds;

                //watch.Start();
                //sorter.RadixSort(data.strAr[i], 100);
                //watch.Stop();
                //result.stringArrayRes[i, 0] = data.strAr[i].GetLength(0);
                //result.stringArrayRes[i, 1] = watch.ElapsedMilliseconds;

                //watch.Restart();
                //sorter.RadixSort(data.strList[i], 100);
                //watch.Stop();
                //result.stringListRes[i, 0] = data.strList[i].Count;
                //result.stringListRes[i, 1] = watch.ElapsedMilliseconds;
            }
            return result;
        }
    }

    class Times
    {
        public long[,] intArrayRes = new long[50, 2];
        public long[,] stringArrayRes = new long[50, 2];
        public long[,] intListRes = new long[50, 2];
        public long[,] stringListRes = new long[50, 2];
        //public long[,] nodeRes = new long[50, 2];
    }
}
