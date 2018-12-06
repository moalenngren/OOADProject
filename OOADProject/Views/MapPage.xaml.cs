using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OOADProject
{
    public partial class MapPage : ContentPage
    {
        Map map;
        List<Gig> gigList;

        public MapPage(List<Gig> gigList)
        {
            InitializeComponent();

            this.gigList = gigList;

            map = new Map(MapSpan.FromCenterAndRadius(
            new Position(36.8961, 10.1865),
                Distance.FromMiles(0.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MapType = MapType.Street;

            Content = map; //stack

            var pos1 = new Position(36.891, 10.1865);
            var pos2 = new Position(36.892, 10.1864);
            var pos3 = new Position(36.893, 10.1863);

            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = pos1,
                Label = "Name1",
                Address = "www.name1.com"
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = pos2,
                Label = "Name2",
                Address = "www.name2.com"
            };

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = pos3,
                Label = "Name3",
                Address = "www.name3.com"
            };

            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
            map.Pins.Add(pin3);


        }
    }
}
