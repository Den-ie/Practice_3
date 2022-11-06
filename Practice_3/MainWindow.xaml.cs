using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using LibMatrix;
using Lib_4;
using System.Windows.Automation;

namespace Practice_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Косов Даниил ИСП-34 \nПрактическая №3 \nВычислить для чисел > 0 функцию x . Результат обработки каждого числа вывести на экран.");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        Matrix<int> _matrix;

        private void CreateArray(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RowCount.Text, out int rowcount) & !int.TryParse(ColumnCount.Text, out int columncount))
            {
                MessageBox.Show("Неверный размер массива", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (columncount <= 0 || rowcount <= 0)
            {
                MessageBox.Show("Размер массива должен быть больше 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _matrix = new Matrix<int>(rowcount, columncount);
            _matrix.Init();

            Table.ItemsSource = _matrix.ToDataTable().DefaultView;

            ClearArray.IsEnabled = true;
            Saving.IsEnabled = true;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            _matrix.Clear();
            Table.ItemsSource = null;

            RowCount.Text = null;
            ColumnCount.Text = null;

            ClearArray.IsEnabled = false;
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            _matrix.Save(Path.Text);
        }

        private void Load_click(object sender, RoutedEventArgs e)
        {
            _matrix.Load(Path.Text);
        }
    }
}
