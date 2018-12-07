using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OOADProject
{
    public partial class MapPage : ContentPage
    {
        Map map;

        public MapPage(Gig gig)
        {
            InitializeComponent();

            Position gigPos = new Position((double.Parse(gig.Venue.Latitude)), (double.Parse(gig.Venue.Longitude)));

            map = new Map(MapSpan.FromCenterAndRadius(gigPos,
                Distance.FromMiles(0.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MapType = MapType.Hybrid;

            Content = map;

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = gigPos,
                Label = gig.Venue.Name,
                Address = gig.Venue.City + ", " + gig.Venue.Country
            };

            map.Pins.Add(pin);
        }
    }
}
