using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace OOADProject 
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public StartPageViewModel()
        {
            SearchCommand = new Command<string>(
            execute: SearchButton,
                canExecute: obj => { return true; }
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SearchCommand { private set; get; }

        private void SearchButton(string obj)
        {
            //VALIDATION HERE

            //SearchBands(obj)


            //RefreshCanExecute???
        }


        /*
        async void SearchBands(string obj)
        {
            List<Object> result = await //call to api here
            await Navigation.PushAsync(new ResultPage(result));
        }*/

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
