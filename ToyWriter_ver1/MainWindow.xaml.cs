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
using System.Collections.ObjectModel;


namespace ToyWriter_ver1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> years = new List<int>();
            for (int i=DateTime.Today.Year; i>=1950; i--)
            {
                years.Add(i);
            }
            comboYear.ItemsSource = years;

            List<string> types = new List<string>();
            types.Add("Micro");
            types.Add("Sedan");
            types.Add("CUV");
            types.Add("SUV");
            types.Add("Hatchback");
            types.Add("Wagon");
            types.Add("Pickup truck");
            types.Add("Van");
            types.Add("Coupe");
            types.Add("Supercar");
            types.Add("Campervan");
            types.Add("Truck");
            comboType.ItemsSource = types;
        }
        private void btnPath_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
