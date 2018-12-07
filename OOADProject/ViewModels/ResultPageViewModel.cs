using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace OOADProject
{
  
    public class ResultPageViewModel 
    {
        public ICommand SelectCommand { private set; get; }

        Gig itemSelected;
        public Gig ItemSelected
        {
            get { return itemSelected; }
            set { itemSelected = value; }
        }

        public List<Gig> GigList { get; set; }

        public ResultPageViewModel(List<Gig> gigList)
        {
            GigList = gigList;
            SelectCommand = new Command<Gig>(TappedItem);

        }

        void TappedItem(Gig gig)
        {
            Application.Current.MainPage.Navigation.PushAsync(new MapPage(itemSelected));
        }

    }
}
