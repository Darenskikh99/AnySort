using AnySort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnySort
{
    class ApplicationVievModel : INotifyPropertyChanged
    {
        private SortableArray myArray;
        public SortableArray MyArray
        {
            get { return myArray; }
            set
            {
                myArray = value;
                OnPropertyChanged("MyArray");
            }
        }

        private RelayCommand addCommand;
        private RelayCommand sortCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                {
                    MyArray.CreateNewRandomArray();
                    MyArray.StringNewArray = MyArray.CreateStringFromArray(MyArray.NewArray);
                });
            }
        }

        public RelayCommand SortCommand
        {
            get
            {
                return sortCommand ??= new RelayCommand(obj =>
                {
                    MyArray.SortByBubble(MyArray.SortedArray);
                    MyArray.StringSortedArray = MyArray.CreateStringFromArray(MyArray.SortedArray);
                });
            }
        }

        public ApplicationVievModel()
        {
            myArray = new SortableArray();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
