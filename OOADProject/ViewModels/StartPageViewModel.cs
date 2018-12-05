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
        public System.Collections.Generic.IList<Xamarin.Forms.Behavior> Behaviors { get; } //????????

        private ValidatableObject<string> _bandName;

        public ValidatableObject<string> BandName
        {
            get
            {
                return _bandName;
            }
            set
            {
                _bandName = value;
                //RaisePropertyChanged(() => BandName); HOW TO FIX THIS?
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SearchCommand { private set; get; }

        public ICommand ValidateBandNameCommand { private set; get; }

        public StartPageViewModel()
        {


            _bandName = new ValidatableObject<string>();

            SearchCommand = new Command<string>(
            execute: SearchButton,
                canExecute: obj => { return true; } //TODO - put this here _bandName.IsValid;
            );

            ValidateBandNameCommand = new Command<string>(
           execute: ValidateByChange,
               canExecute: obj => { return true; } 
           );
        }


        //Adding validations to bandname
        private void AddValidations()
        {
            _bandName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A bandname is required."
            });

            //Maybe add validation that checks if band name exists in database?
        }

        private bool Validate()
        {
            bool isValidBand = ValidateBandName();
            return isValidBand;
        }

        //Validate method on class ValidatableObject
        private bool ValidateBandName()
        {
            return _bandName.Validate();
        }

        //???
        private void ValidateByChange(string obj)
        {
            _bandName.Value = obj;
            AddValidations();
        }

        private void SearchButton(string obj)
        {

            //SearchBands(obj) 

            //RefreshCanExecute???
            List<Object> result = new List<Object>();

            //MessagingCenter.Send(this, "Result", "Sticky Fingers");

            MessagingCenter.Send("Sticky Fingers", "Update");

            App.Current.MainPage.Navigation.PushAsync(new ResultPage());
            //MessengerInstance.Send(new NavigateToViewNotification() { ToView = "Dashboard" });
        }


        /*
        async void SearchBands(string obj)
        {
            List<Object> result = await //call to api here
            await Navigation.PushAsync(new ResultPage(result));
            App.Current.MainPage.Navigation.PushAsync(new ResultPage(result));           
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
