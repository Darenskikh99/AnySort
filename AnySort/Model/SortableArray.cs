using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnySort
{
    class SortableArray : INotifyPropertyChanged
    {
        private const int ARRAYSIZE = 10;
        private int[] newArray = new int[ARRAYSIZE];
        private int[] sortedArray = new int[ARRAYSIZE];
        private string stringNewArray;
        private string stringSortedArray;

        public string StringNewArray
        {
            get { return stringNewArray; }
            set 
            { 
                stringNewArray = value;
                OnPropertyChanged("StringNewArray");
            }
        }

        public string StringSortedArray
        {
            get { return stringSortedArray; }
            set
            {
                stringSortedArray = value;
                OnPropertyChanged("StringSortedArray");
            }
        }

        public int[] NewArray
        {
            get { return newArray; }
            set
            {
                newArray = value;
                OnPropertyChanged("NewArray");
            }
        }

        public int[] SortedArray
        {
            get { return sortedArray; }
            set
            {
                sortedArray = value;
                OnPropertyChanged("SortedArray");
            }
        }

        public void CreateNewRandomArray()
        {
            Random rnd = new();
            for (var i = 0; i < ARRAYSIZE; i++)
            {
                newArray[i] = rnd.Next(10);
                sortedArray[i] = newArray[i];
            }

        }

        public string CreateStringFromArray(int[] myArray)
        {
            string? creatableString = null;
            for(var i = 0; i < ARRAYSIZE; i++)
            {
                creatableString += myArray[i].ToString();
            }

            if (creatableString != null)
            {
                return creatableString;
            }
            else return "Пустой массив";
        }

        public int[] SortByBubble(int[] newArray)
        {
            int[] myArray = newArray;
            for(var i = 0; i < ARRAYSIZE - 1; i++)
            {
                for(var j = 0; j < ARRAYSIZE - 1 - i; j++)
                {
                    if (myArray[j] > myArray[j + 1])
                    {
                        var swap = myArray[j];
                        myArray[j] = myArray[j + 1];
                        myArray[j + 1] = swap;
                    }
                }
            }
            return myArray;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
