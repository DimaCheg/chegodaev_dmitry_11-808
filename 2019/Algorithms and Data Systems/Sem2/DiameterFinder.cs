using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace SemTask2
{
    class DiameterFinder
    {
        public double FindDiameter(List<Point> set)
        {
            var hull = BuildHull(set);
            var maxDist = 0.0;
            var p = hull.First;
            var q = p.Next;
            while (q.Next != null &&
            GetArea(p.Value, p.Next.Value, q.Next.Value) > GetArea(p.Value, p.Next.Value, q.Value))
                q = q.Next;


            var q0 = q;
            var p0 = p;
            while (q != p0)
            {
                p = p.Next;
                CheckMax(p, q, ref maxDist);
                while (GetArea(p.Value, p.Next.Value, q.Next.Value) >
                    GetArea(p.Value, p.Next.Value, q.Value))
                {
                    q = q.Next;
                    if (p != q0 || q != p0) // .value?
                        CheckMax(p, q, ref maxDist);
                }
                if (GetArea(p.Value, p.Next.Value, q.Next.Value) ==
                    GetArea(p.Value, p.Next.Value, q.Value) &&
                    (p != q0 || q != hull.Last))
                {
                    CheckMax(p, q.Next, ref maxDist);
                }
            }
            return maxDist;
        }

        private double GetDist(Point p1, Point p2) =>
            Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

        private double GetArea(params Point[] points) =>
            ((points[0].X - points[2].X) * (points[1].Y - points[2].Y) -
            (points[0].Y - points[2].Y) * (points[1].X - points[2].X)) / 2;

        private void CheckMax(LinkedListNode<Point> p1, LinkedListNode<Point> p2, ref double max)
        {
            var dist = GetDist(p1.Value, p2.Value);
            if (dist > max)
                max = dist;
        }


        private LinkedList<Point> BuildHull(List<Point> set)
        {
            if (set.Count == 0) return new LinkedList<Point>();
            set.Sort();
            List<Point> h = new List<Point>();

            // lower hull
            foreach (var pt in set)
            {
                while (h.Count >= 2 && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            // upper hull
            int t = h.Count + 1;
            for (int i = set.Count - 1; i >= 0; i--)
            {
                Point pt = set[i];
                while (h.Count >= t && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            h.RemoveAt(h.Count - 1);
            return new LinkedList<Point>(h);
        }

        private static bool Ccw(Point a, Point b, Point c)
        {
            return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
        }

        private Point[] BuildHull1(Point[] set)
        {
            return new Point[0];
        }
    }
}
