using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleXMLWriter_MVVM
{
    public class InputViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;

        public RelayCommand AddCommand { get; private set; }
        public RelayCommand DelCommand { get; private set; }

        private List<string> _types = new List<string>
        {
            "Micro",
            "Sedan",
            "CUV",
            "SUV",
            "Hatchback",
            "Wagon",
            "Pickup truck",
            "Van",
            "Coupe",
            "Supercar",
            "Campervan",
            "Truck"
        };
        public List<string> Types
        {
            get
            {
                return _types;
            }
        }

        private string _model;
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        private int _year;
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                OnPropertyChanged("Year");
            }
        }

        private string _fuelType;
        public string FuelType
        {
            get
            {
                return _fuelType;
            }
            set
            {
                _fuelType = value;
                OnPropertyChanged("FuelType");
            }
        }

        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        


        public InputViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            AddCommand = new RelayCommand(Add);
            DelCommand = new RelayCommand(Del);
        }

        private void Del()
        {
            mainViewModel.DelItem();
        }

        private void Add()
        {
            mainViewModel.AddItem(Model, Type, Year, FuelType, Color);
        }
    }
}
