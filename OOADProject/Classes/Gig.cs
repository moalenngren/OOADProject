using System;
using System.Collections.Generic;

namespace OOADProject
{
    public class Gig
    {

        public string Venue { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Gig(Dictionary<string, string> venue, Dictionary<string, string> gig)
        {

            this.Venue = venue["name"];
            this.City = venue["city"];
            this.Country = venue["country"];
            this.Date = DateTime.Parse(gig["datetime"]);
            this.Latitude = venue["latitude"];
            this.Longitude = venue["longitude"];

        }

        public Gig()
        {
        }
    }
}
