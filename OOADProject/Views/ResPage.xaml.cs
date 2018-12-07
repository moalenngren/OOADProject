using System;
using System.Collections.Generic;
using OOADProject.Classes;
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

            BindingContext = new ResultPageViewModel(gigList);
        }
    }
}
