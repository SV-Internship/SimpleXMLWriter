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

using Microsoft.WindowsAPICodePack.Dialogs;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

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

        ObservableCollection<Car> listData;
        string rbFuelType;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listData = new ObservableCollection<Car>();
            listCar.ItemsSource = listData;
                        
            List<int> years = new List<int>();
            for (int i=DateTime.Today.Year; i>=1950; i--)
            {
                years.Add(i);
            }
            cbYear.ItemsSource = years;

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
            cbType.ItemsSource = types;
        }
        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new CommonOpenFileDialog();
                dlg.Filters.Add(new CommonFileDialogFilter("xml", "xml"));
                if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tbPath.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred from {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var model = tbModel.Text;
                var type = cbType.SelectedItem.ToString();
                var year = cbYear.SelectedItem.ToString();
                var fuelType = rbFuelType;
                var color = tbColor.Text;

                listData.Add(new Car(model, type, year, fuelType, color));

                tbModel.Text = "";
                cbType.Text = "";
                cbYear.Text = "";
                tbColor.Text = "";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred from {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if(listCar.SelectedItem is Car car)
            {
                listData.Remove(car);
            }
        }

        private void comboYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rbFuelType1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rbFuelType = rb.Content as string;
        }

        private void listCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(listData.GetType());
            using (StreamWriter wr = new StreamWriter(tbPath.Text))
            {
                xs.Serialize(wr, listData) ;
            }
        }
    }
}
