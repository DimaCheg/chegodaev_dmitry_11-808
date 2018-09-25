using System;

namespace Rectangles
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * практика два прямоугольника
     */ 
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            if (r1.Left > r2.Left + r2.Width || // первый правее второго
                r1.Left + r1.Width < r2.Left || // первый левее второго
                r1.Top > r2.Top + r2.Height || // первый ниже второго
                r1.Top + r1.Height < r2.Top // первый выше второго, учитывая направление осей
                )
            {
                return false; // тогда не пересекаются
            }
            else
            {
                return true;
            }
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            int left = Math.Max(r1.Left, r2.Left);
            int right = Math.Min(r1.Left + r1.Width, r2.Left + r2.Width);
            int length = Math.Max(right - left, 0); // длина участка пересечения
            int top = Math.Max(r1.Top, r2.Top);
            int bottom = Math.Min(r1.Top + r1.Height, r2.Top + r2.Height);
            int height = Math.Max(bottom - top, 0); //высота участка пересечения
            return length * height;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (IsInside(r1.Left, r1.Left + r1.Width, r1.Top, r1.Top + r1.Height,
                r2.Left, r2.Left + r2.Width, r2.Top, r2.Top + r2.Height))
            {
                return 1;
                // проверка всех сторон на "вложенность"
                // левая 1ого левее, верхняя 1ого выше и тд
                // номер 2ого массива "с нуля" = 1
            }
            else if (IsInside(r2.Left, r2.Left + r2.Width, r2.Top, r2.Top + r2.Height,
                r1.Left, r1.Left + r1.Width, r1.Top, r1.Top + r1.Height))
            {
                return 0;
            }
            else { return -1; }
        }

        public static bool IsInside(int left1, int right1, int top1, int bottom1,
            int left2, int right2, int top2, int bottom2)
        {
            /* проверка, лежит ли второй прямоугольник внутри первого.
             * первый и второй - в соответствии с порядком передачи значений в метод
             */
            if (left1 <= left2 &&
                top1 <= top2 &&
                right1 >= right2 &&
                bottom1 >= bottom2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}