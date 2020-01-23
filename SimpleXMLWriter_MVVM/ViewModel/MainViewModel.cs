
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace SimpleXMLWriter_MVVM
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand OpenPathCommand { get; private set; }
        public ICommand SavePathCommand { get; private set; }

        public InputViewModel InputVM { get; set; }
        public string XmlPath
        {
            get
            {
                return _xmlPath;
            }
            set
            {
                _xmlPath = value;
                OnPropertyChanged("XmlPath");
            }
        }
        public ObservableCollection<Car> ListData { get => _listData; set => _listData = value; }
        private ObservableCollection<Car> _listData;
        private string _xmlPath;

        public Car SelectedItem { get; set; }

        public MainViewModel()
        {
            ListData = new ObservableCollection<Car>();
            InputVM = new InputViewModel(this);
            OpenPathCommand = new RelayCommand(OpenPath);
            SavePathCommand = new RelayCommand(SavePath);
        }

        private void OpenPath()
        {
            try
            {
                var dlg = new CommonOpenFileDialog();
                dlg.Filters.Add(new CommonFileDialogFilter("xml", "xml"));
                if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    XmlPath = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred from {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine(ex.ToString());
            }
        }
        private void SavePath()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(ListData.GetType());
                using (StreamWriter wr = new StreamWriter(XmlPath))
                {
                    xs.Serialize(wr, ListData);
                }
                MessageBox.Show("successed");
                ListData.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred from {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine(ex.ToString());
            }
        }

        public void DelItem()
        {
            if (SelectedItem != null)
                ListData.Remove(SelectedItem);
        }

        public void AddItem(string model, string type, string year, string fuelType, string color)
        {
            ListData.Add(new Car(model, type, year, fuelType, color));

        }
    }
}

