using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace LibMatrix
{
    public class Matrix<T>
    {
        private T[,] _item;
        private int _row;
        private int _column;

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _item.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _item.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _item.GetLength(1); j++)
                {
                    row[j] = _item[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

        public Matrix(int firstcapacity, int secondcapacity)
        {
            _item = new T[firstcapacity, secondcapacity];
            _row = firstcapacity;
            _column = secondcapacity;
        }
        
        public int LengthRow { get; private set; }

        public int LengthColumn { get; private set; }

        public int Row
        {
            get => _row;
            private set
            {
                if (value == _row)
                {
                    return;
                }

                _row = value;
                // Resize двумерного массива
            }

        }

        public int Column
        {
            get => _column;
            private set
            {
                if (value == _column)
                {
                    return;
                }

                _column = value;
                // Resize двумерного массива
            }
        }

        public T this[int indexFirst, int indexSecond]
        {
            get { return _item[indexFirst, indexSecond]; }
            set { _item[indexFirst, indexSecond] = value; }
        }
    }
}
