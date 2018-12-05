using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OOADProject
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();

            BindingContext = new ResultPageViewModel(); //?
        }

        //Move this to MV
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        
            Navigation.PushAsync(new MapPage());
        }
    }
}
