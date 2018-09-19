using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		//  Ниже — это XML документация, её использует ваша среда разработки, 
		// чтобы показывать подсказки по использованию методов. 
		// Но писать её естественно не обязательно.
		/// <param name="v">Начальная скорость</param>
		/// <param name="distance">Расстояние до цели</param>
		/// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
		public static double FindSightAngle(double v, double distance)
		{
            /* distance = speed^2 * sin(2a) /g
             * a = angle;
             */
            double g = 9.8; //ускорение свободного падения
            if (g * distance <= 2 * v * v) 
            {
                //конечная формула
                double angle = Math.Asin(g * distance / v / v) / 2;
			    return angle;
            }
            else
            {
                return Double.NaN;
            }
           
		}
	}
}