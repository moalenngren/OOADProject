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

        public ValidatableObject<string> Name { get; set; } = new ValidatableObject<string>() { Value = "" };


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SearchCommand { private set; get; }

        public ICommand ValidateBandNameCommand { private set; get; }

        private string welcomeString = "Welcome! Enter artist to find upcoming shows.";

        public string WelcomeString
        {
            get { return welcomeString; }
            set
            {
                SetProperty(ref welcomeString, value);
            }
        }

        public StartPageViewModel()
        {
            SearchCommand = new Command<string>(
            execute: SearchButton,
                canExecute: obj =>
                {
                    return Name.IsValid;
                }
            );

            ValidateBandNameCommand = new Command<TextChangedEventArgs>(ValidateByChange);
            AddValidations();
            Name.Validate();
            RefreshCanExecute();
        }


        //Adding validations to bandname
        private void AddValidations()
        {
            Name.Validations.Add(new IsNotNullOrEmptyRule<string>
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

        private bool ValidateBandName()
        {
            return Name.Validate();
        }

        private void ValidateByChange(TextChangedEventArgs obj)
        {
            Validate();
            RefreshCanExecute();
        }

        private void SearchButton(string obj)
        {
            SearchBands(obj);
        }

        private void RefreshCanExecute()
        {
            (SearchCommand as Command).ChangeCanExecute();
        }

        void SearchBands(string obj)
        {
            List<Gig> gigList = APIModel.getGigs(Name.Value);
            if (gigList.Count > 0)
            {
                Application.Current.MainPage.Navigation.PushAsync(new ResPage(gigList));
            }
            else
            {
                Name.IsValid = false;
                WelcomeString = "Sorry. Try again!";
                Name.Value = "";
                RefreshCanExecute();
            }
        }

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
