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

        //public RelayCommand AddCommand { get; private set; }
        //public RelayCommand DelCommand { get; private set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }


        //public InputViewModel(MainViewModel mainViewModel)
        //{
        //    this.mainViewModel = mainViewModel;

        //    AddCommand = new RelayCommand(Add);
        //    DelCommand = new RelayCommand(Del);
        //}

        //private void Del()
        //{
        //    mainViewModel.DelItem();
        //}

        //private void Add()
        //{
        //    mainViewModel.AddItem(Name, Age);
        //}
    }
}
