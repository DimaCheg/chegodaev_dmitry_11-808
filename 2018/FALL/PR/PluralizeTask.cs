namespace Pluralize
{
    /* автор: Чегодаев Дима
     * группа 11-808
     * практика «Рубль -лей -ля»
     */

    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            if ((count % 100) >= 11 && (count % 100) <= 19)
            {
                return "рублей";
            }
            else
            {
                switch (count % 10)
                {
                    case 1: return "рубль"; break;
                    case 2:
                    case 3:
                    case 4: return "рубля"; break;
                    default: return "рублей";
                }
            }
        }
    }
}