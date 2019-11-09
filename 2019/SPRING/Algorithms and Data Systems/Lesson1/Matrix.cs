using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    public class Matrix
    {
        double[,] matrix;

        public Matrix()
        {
            matrix = new double[0, 0];
        }

        public Matrix(int size)
        {
            matrix = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
        }

        public double[,] Multiply(double[,] m1, double[,] m2)
        {
            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    for (int k = 0; k < m2.GetLength(0); k++)
                        result[i, j] += m1[i, k] * m2[k, j];
                }
            }
            return result;
        }

        public double[,] ToSquare(double[,] m)
        {
            var result = new double[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    for (int k = 0; k < m.GetLength(0); k++)
                        result[i, j] += m[i, k] * m[k, j];
                }
            }
            return result;
        }

        public double[,] RaiseToPower(double[,] m, int power)
        {
            int log = 0;
            int res = 1;
            double[,] resultMatrix = m;
            while (res < power)
            {
                res *= 2;
                log++;
            }
            log--;
            for (int i = 0; i < log; i++)
            {
                resultMatrix = ToSquare(resultMatrix);
            }
            for (int i = 0; i < power - log; i++)
            {
                resultMatrix = Multiply(resultMatrix, m);
            }
            return resultMatrix;
        }
    }
}
