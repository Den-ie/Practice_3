using System;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media;
using LibMatrix;

namespace Lib_4
{
    public static class ExtensionMatrix
    {
        /// <summary>
        /// Инициализация матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="min">Минималное значение</param>
        /// <param name="max">Максимальное значение</param>
        public static void Init(this Matrix<double> matrix, int min = -10, int max = 11)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    matrix[i, j] = (rnd.Next(min, max));
                }
            }
        }

        /// <summary>
        /// Вычисление по заданию
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public static void Calculate(this Matrix<double> matrix)
        {
            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] = (Math.Round(Math.Sqrt(matrix[i, j]), 2));
                    }
                }
            }
        }
    }
}
