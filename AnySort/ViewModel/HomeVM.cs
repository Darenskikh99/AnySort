using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnySort.Utilities;
using System.Windows.Input;

namespace AnySort.ViewModel
{
    class HomeVM : Utilities.ViewModelBase
    {
        private object _currentview;
        public object CurrentView
        {
            get { return _currentview; }
            set
            {
                _currentview = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public ICommand HomePageCommand { get; set; }
        public ICommand SortPageCommand { get; set; }
        public ICommand FoundPageCommand { get; set; }

        private void Home(object view)
        {
            CurrentView = new HomeVM();
        }
        private void Sort(object view)
        {
            CurrentView = new HomeVM();
        }

        private void Found(object view)
        {
            CurrentView = new FoundVM();
        }

        public HomeVM()
        {
            HomePageCommand = new RelayCommand(Home);
            SortPageCommand = new RelayCommand(Sort);
            FoundPageCommand = new RelayCommand(Found);

            CurrentView = new HomeVM();
        }
    }
}
