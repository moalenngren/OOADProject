using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OOADProject
{
    public partial class ResPage : ContentPage
    {
        public List<Gig> GigList;
        public ResPage(List<Gig> gigList)
        {
            InitializeComponent();
            this.GigList = gigList;
            BindingContext = new ResultPageViewModel(gigList); //?
            //BindingContext = viewModel = new DeviceCheckViewModel(this.Navigation);
        }

        //Move this to VM
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            Navigation.PushAsync(new MapPage(GigList));
        }
    }
}
