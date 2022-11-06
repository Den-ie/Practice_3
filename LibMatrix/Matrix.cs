using System;
using System.IO;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using LibMatrix;

namespace LibMatrix
{
    public class Matrix<T>
    {
        private T[,] _matrix;
        private int _row;
        private int _column;

        public Matrix(int firstcapacity, int secondcapacity)
        {
            _matrix = new T[firstcapacity, secondcapacity];
            _row = firstcapacity;
            _column = secondcapacity;
        }

        private readonly int _defaultrow = 5;
        private readonly int _defaultcolumn = 5;

        public T this[int indexSecond, int indexFirst]
        {
            get { return _matrix[indexFirst, indexSecond]; }
            set { _matrix[indexFirst, indexSecond] = value; }
        }

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
            }
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    row[j] = _matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

        private static readonly BinaryFormatter _formatter = new ();

        public void Save(object data, string path)
        {
            using (FileStream stream = new(path, FileMode.Create))
            {
                _formatter.Serialize(stream, data);
            }
        }
        
        public void Load(string path)
        {
            string fullPath = @".\object.matrix";
            T[,] data;
            BinaryFormatter formatter = new();

            using (FileStream stream = new(fullPath, FileMode.Open))
            {
                data = _formatter.Deserialize(stream) as T[,];
            }
        }

        public void Clear()
        {
            Row = _defaultrow;
            Column = _defaultcolumn;

            _matrix = new T[_defaultcolumn, _defaultrow];
        }
    }
}
