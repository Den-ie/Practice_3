using System;
using System.Data;
using LibMatrix;

namespace Lib_4
{
    public static class ExtensionMatrix
    {
        public static void Init(this Matrix<int> matrix, int min = -10, int max = 11)
        {
            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    Random rnd = new Random();

                    matrix[i,j] = (rnd.Next(min, max));
                }
            }
        }
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
