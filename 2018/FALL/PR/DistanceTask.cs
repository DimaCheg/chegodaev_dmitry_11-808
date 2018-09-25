using System;

namespace DistanceTask
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * практика Расстояние до отрезка
     */

    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double distance;
            if ((ax - bx == 0) && (ay - by == 0))
            {
                /* если точки А и В совпадают,
                 * то может произойти ошибка: деление на ноль
                 * поэтому рассматриваем исключение,
                 * где искомое расстояние - длина отрезка ОА
                 */ 
                distance = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
            }
            else
            {
                double t = ((x - ax) * (bx - ax) + (y - ay) * (by - ay));
                t /= ((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
                if (t < 0)
                {
                    t = 0;
                }
                if (t > 1)
                {
                    t = 1;
                }
                distance = (ax - x + (bx - ax) * t) * (ax - x + (bx - ax) * t);
                distance += (ay - y + (by - ay) * t) * (ay - y + (by - ay) * t);
                distance = Math.Sqrt(distance);
            }
            return distance;
        }
    }
}