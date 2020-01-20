using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;

namespace ToyWriter_ver2.ViewModel
{
    public class ReaderViewModel : INotifyPropertyChanged
    {
        private bool _nameorder;
        private bool _typeorder;
        private bool _yearorder;
        private bool _fuelorder;
        private bool _colororder;

        private string _categoryChange;

        public string CategoryChange
        {
            get { return _categoryChange; }
            set
            {
                _categoryChange = value;
                string[] parser = _categoryChange.Split(' ');
                _categoryChange = parser[1];
                OnPropertyChanged("CategoryChange");
            }
        }

        private string _filename;

        public string Filename
        {
            get { return _filename; }
            set
            {
                _filename = value;
                OnPropertyChanged("Filename");
            }
        }

        private ObservableCollection<Car> _resetCarList;

        public ObservableCollection<Car> ResetCarList
        {
            get => _resetCarList;
            set
            {
                _resetCarList = value;
                OnPropertyChanged("ResetCarList");
            }
        }

        public ObservableCollection<Car> CarList
        {   
            get => _carList;    
            set { 
                _carList = value;
                OnPropertyChanged("CarList");
            } 
        }

        private ObservableCollection<Car> _carList;

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }

            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");

                if (String.IsNullOrEmpty(_searchText))
                    CarList = ResetCarList;

                else
                {
                    if (CategoryChange == "Car")
                    {
                        CarList = new ObservableCollection<Car>(CarList.Where(i => i.carName.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
                    }
                    
                    else if (CategoryChange == "Type")
                    {
                        CarList = new ObservableCollection<Car>(CarList.Where(i => i.carType.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
                    }

                    else if (CategoryChange == "Year")
                    {
                        CarList = new ObservableCollection<Car>(CarList.Where(i => i.carYear.ToString().IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
                    }

                    else if (CategoryChange == "Fuel")
                    {
                        CarList = new ObservableCollection<Car>(CarList.Where(i => i.carFuel.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
                    }

                    else
                    {
                        CarList = new ObservableCollection<Car>(CarList.Where(i => i.carColor.IndexOf(_searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
                    }
                }
            }
        }

        public ReaderViewModel()
        {
            CarList = new ObservableCollection<Car>();
            _nameorder = true;
            _typeorder = true;
            _yearorder = true;
            _fuelorder = true;
            _colororder = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand _filecommand;

        public ICommand FileCommand
        {
            get
            {
                return ((this._filecommand) ?? (this._filecommand = new DelegateCommand(fileOpen)));
            }
        }

        private ICommand _namesortcommand;

        public ICommand NameSortCommand
        {
            get
            {
                return ((this._namesortcommand) ?? (this._namesortcommand = new DelegateCommand(NameColumnHeaderCilckSorted)));
            }
        }

        private ICommand _typesortcommand;
        public ICommand TypeSortCommand
        {
            get
            {
                return ((this._typesortcommand) ?? (this._typesortcommand = new DelegateCommand(TypeColumnHeaderCilckSorted)));
            }
        }

        private ICommand _yearsortcommand;
        public ICommand YearSortCommand
        {
            get
            {
                return ((this._yearsortcommand) ?? (this._yearsortcommand = new DelegateCommand(YearColumnHeaderCilckSorted)));
            }
        }

        private ICommand _fuelsortcommand;
        public ICommand FuelSortCommand
        {
            get
            {
                return ((this._fuelsortcommand) ?? (this._fuelsortcommand = new DelegateCommand(FuelColumnHeaderCilckSorted)));
            }
        }

        private ICommand _colorsortcommand;
        public ICommand ColorSortCommand
        {
            get
            {
                return ((this._colorsortcommand) ?? (this._colorsortcommand = new DelegateCommand(ColorColumnHeaderCilckSorted)));
            }
        }
        
        public object Resources { get; private set; }

        private void fileOpen()
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                if (openFile.ShowDialog() == true)
                {
                    Filename = openFile.FileName;

                    for (int i = CarList.Count() - 1; i >= 0; i--)
                    {
                        CarList.RemoveAt(i);
                    }

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Filename);

                    XmlNodeList xnList = xmlDoc.SelectNodes("ArrayOfCar/Car");

                    foreach (XmlNode xn in xnList)
                    {
                        CarList.Add(new Car(xn["Model"].InnerText, xn["Type"].InnerText, int.Parse(xn["Year"].InnerText), xn["FuelType"].InnerText, xn["Color"].InnerText));
                    }

                    ResetCarList = CarList;
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void NameColumnHeaderCilckSorted()
        {
            if(_nameorder)
            {
                CarList = new ObservableCollection<Car>(CarList.OrderBy(Car => Car.carName).ToList());
                _nameorder = false;
            }
            else
            {
                CarList = new ObservableCollection<Car>(CarList.OrderByDescending(Car => Car.carName).ToList());
                _nameorder = true;
            }
        }

        
        private void TypeColumnHeaderCilckSorted()
        {
            if (_typeorder)
            {
                CarList = new ObservableCollection<Car>(CarList.OrderBy(Car => Car.carType).ToList());
                _typeorder = false;
            }
            else
            {
                CarList = new ObservableCollection<Car>(CarList.OrderByDescending(Car => Car.carType).ToList());
                _typeorder = true;
            }
        }

        private void YearColumnHeaderCilckSorted()
        {
            if (_yearorder)
            {
                CarList = new ObservableCollection<Car>(CarList.OrderBy(Car => Car.carYear).ToList());
                _yearorder = false;
            }
            else
            {
                CarList = new ObservableCollection<Car>(CarList.OrderByDescending(Car => Car.carYear).ToList());
                _yearorder = true;
            }
        }

        private void FuelColumnHeaderCilckSorted()
        {
            if (_fuelorder)
            {
                CarList = new ObservableCollection<Car>(CarList.OrderBy(Car => Car.carFuel).ToList());
                _fuelorder = false;
            }
            else
            {
                CarList = new ObservableCollection<Car>(CarList.OrderByDescending(Car => Car.carFuel).ToList());
                _fuelorder = true;
            }
        }

        private void ColorColumnHeaderCilckSorted()
        {
            if (_colororder)
            {
                CarList = new ObservableCollection<Car>(CarList.OrderBy(Car => Car.carColor).ToList());
                _colororder = false;
            }
            else
            {
                CarList = new ObservableCollection<Car>(CarList.OrderByDescending(Car => Car.carColor).ToList());
                _colororder = true;
            }
        }
        
    }

    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute) : this(execute, null) { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object o)
        {
            if(this.canExecute == null)
            {
                return true;
            }

            return this.canExecute();
        }

        public void Execute(object o) { this.execute(); }

        public void RaiseCanExecuteChanged()
        {
            if(this.CanExecuteChanged == null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
