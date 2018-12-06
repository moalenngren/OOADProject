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

        public ResultPageViewModel(List<Gig> gigList)
        {

            App.Current.MainPage.Title = "Band name" + " gigs"; //Does not work
                                                                //this._gigList = gigList;

            this._gigList = gigList; // new List<Gig>();

            /* HUR GÖRA DETTA???
            MessagingCenter.Subscribe<string>(this, "AddNew", (arg) =>
            {
                Gig gig3 = new Gig();
                //gig3.Venue = "";
                gig3.Venue.City = "Gothenburg";
                gig3.Venue.Country = "SWEDEN";
                gig3.DateTime = "2017-03-19T11:00:00";
                gig3.Venue.Latitude = "36.12714";
                gig3.Venue.Longitude = "-115.1629562";

                _gigList.Add(gig3);
            }); */


            /*MessengerInstance.Register<NavigateToViewNotification>(this, ntv => {
                // here imlement the navigation ntv.ToView has the info to which view
                ResultPage;
                }); */
        }

        //FIXA DENNA!!!
        void ItemSelected(/*object sender, SelectedItemChangedEventArgs e*/)
        {
            //if (e.SelectedItem == null)
            //return; 


            //Push to map view, pass lat/long
            App.Current.MainPage.Navigation.PushAsync(new MapPage(GigList));
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
