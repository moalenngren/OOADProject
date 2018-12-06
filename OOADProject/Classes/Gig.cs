using System;
using System.Collections.Generic;
using System.Globalization;

namespace OOADProject
{
    public class Gig
    {
        public Venue Venue { get; set; }
        public string Datetime { get; set; }
        //public string Month { get; set; } //Denna 
       // public string Day { get; set; } //Denna

        public Gig()
        {
          /*  DateTime date = DateTime.Parse(Datetime);
            this.Month = date.ToString("MMM", CultureInfo.InvariantCulture);
            this.Day = date.ToString("dd", CultureInfo.InvariantCulture); */


            /*
            this.Venue = venue["name"];
            this.City = venue["city"];
            this.Country = venue["country"];
            this.Date = DateTime.Parse(gig["datetime"]);
            this.Latitude = venue["latitude"];
            this.Longitude = venue["longitude"];
            this.Month = (Date.Month).ToString(); //Fix
            this.Day = (Date.Day).ToString(); //Fix 
            */

        }


    }

    public class Venue
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public Venue()
        {

        }

    }
}
