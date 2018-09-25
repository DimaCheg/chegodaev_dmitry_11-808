using System;

namespace Cond1
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * семинарская задача */

    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string finish = Console.ReadLine();
            int xMove = Math.Abs(start[0] - finish[0]);
            int yMove = Math.Abs(start[1] - finish[1]);
            Console.WriteLine(Bishop(xMove, yMove));
            Console.WriteLine(Queen(xMove, yMove));
        }

        //названия фигур взяты из википедии
        public static string Bishop (int x, int y)
        {
            if (x == y) return "корректный ход для слона";
            else return "не корректный ход для слона";
        }

        public static string Knight(int x, int y)
        {
            if ((x == 2 * y || y == 2 * x) && x + y == 3) return "корректный ход для коня";
            else return "не корректный ход для коня";
        }

        public static string Rock(int x, int y)
        {
            if (x * y == 0) return "корректный ход для ладьи";
            else return "корректный ход для ладьи";
        }

        public static string Queen (int x, int y)
        {
            if (x == y || x * y == 0) return "корректный ход для ферзя";
            else return "не корректный ход для ферзя";
        }

        public static string King(int x, int y)
        {
            if (x <= 1 && y <= 1) return "корректный ход для короля";
            else return "не корректный ход для короля";
        }

    }
}
