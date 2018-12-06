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
        //public System.Collections.Generic.IList<Xamarin.Forms.Behavior> Behaviors { get; } //????????

       public ValidatableObject<string> Name { get; set; } = new ValidatableObject<string>() { Value = "" };
         
     
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SearchCommand { private set; get; }

        public ICommand ValidateBandNameCommand { private set; get; }
       
         public StartPageViewModel()
        {
            SearchCommand = new Command<string>(
            execute: SearchButton,
                canExecute: obj => {
                    return Name.IsValid;
             } //TODO - put this here _bandName.IsValid;
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

        //Validate method on class ValidatableObject
        private bool ValidateBandName()
        {
            return Name.Validate();
        }

        //When writing a letter in entry
        private void ValidateByChange(TextChangedEventArgs obj)
        {
            Validate();
            RefreshCanExecute();
        }

        private void SearchButton(string obj)
        {

            SearchBands(obj);

            //RefreshCanExecute???


            //MessagingCenter.Send(this, "Result", "Sticky Fingers");

            //MessagingCenter.Send("Sticky Fingers", "Update");

            //App.Current.MainPage.Navigation.PushAsync(new //ResultPage());
            //MessengerInstance.Send(new NavigateToViewNotification() { ToView = "Dashboard" });
        }

        private void RefreshCanExecute()
        {
            (SearchCommand as Command).ChangeCanExecute();

        }



        /*async*/
        void SearchBands(string obj)
        {
            List<Gig> gigList = APIModel.getGigs();
            //List<Gig> result = /*await*/ APIModel.getGigs(); //call to api here
            //await Navigation.PushAsync(new ResultPage(result));
            Application.Current.MainPage.Navigation.PushAsync(new ResPage(gigList));
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
