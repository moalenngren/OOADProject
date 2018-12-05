using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace OOADProject
{
  
    public class ResultPageViewModel //: INotifyPropertyChanged
    {
        public ICommand SelectCommand { private set; get; }

        Gig selectedGig;
        public Gig SelectedGig
        {
            get { return selectedGig; }
            set { selectedGig = value; }
        }


        private List<Gig> _gigList;

        public List<Gig> GigList {
            get
            {
                return _gigList;
            }

            set
            {
                _gigList = value;
            }
        }

        public ResultPageViewModel(/*List<GigClass> gigList*/)
        {

            App.Current.MainPage.Title = "Band name" + " gigs";
            //this._gigList = gigList;

            this._gigList = new List<Gig>();

            Gig gig1 = new Gig();
            gig1.Venue = "Skövde Kulturhus";
            gig1.City = "Skövde";
            gig1.Country = "Sweden";
            gig1.Date = DateTime.Parse("2017-03-19T11:00:00");
            gig1.Latitude = "36.12714";
            gig1.Longitude = "-115.1629562";

            Gig gig2 = new Gig();
            gig2.Venue = "Cocktails and Beer";
            gig2.City = "Las Vegas";
            gig2.Country = "USA";
            gig2.Date = DateTime.Parse("2017-03-19T11:00:00");
            gig2.Latitude = "36.12714";
            gig2.Longitude = "-115.1629562";

            _gigList.Add(gig1);
            _gigList.Add(gig2);


            MessagingCenter.Subscribe<string>(this, "AddNew", (arg) =>
            {
                Gig gig3 = new Gig();
                gig3.Venue = arg;
                gig3.City = "Gothenburg";
                gig3.Country = "SWEDEN";
                gig3.Date = DateTime.Parse("2017-03-19T11:00:00");
                gig3.Latitude = "36.12714";
                gig3.Longitude = "-115.1629562";

                _gigList.Add(gig3);
            });


            /*MessengerInstance.Register<NavigateToViewNotification>(this, ntv => {
                // here imlement the navigation ntv.ToView has the info to which view
                ResultPage;
                }); */
        }

        void ItemSelected(/*object sender, SelectedItemChangedEventArgs e*/)
        {
            //if (e.SelectedItem == null)
            //return; 

            //await DisplayAlert("Item tapped", "An item was tapped", "OK");


            //Push to map view, pass lat/long
            App.Current.MainPage.Navigation.PushAsync(new MapPage());
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
