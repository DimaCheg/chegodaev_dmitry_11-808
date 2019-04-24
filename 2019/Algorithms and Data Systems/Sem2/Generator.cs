using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SemTask2
{
    class Generator
    {
        public List<Point> GetPoints(int count)
        {
            var rand = new Random();
            var list = new List<Point>();
            for (int i=0;i<count; i++)
            {
                list.Add(new Point(rand.Next(-100, 100), rand.Next(-100, 100)));
            }
            return list;
        }
    }
}
