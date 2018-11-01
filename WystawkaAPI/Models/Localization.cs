using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WystawkaAPI.Models
{
    public class Localization
    {
        public int LocalizationID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public Coords Coords { get; set; }
    }

    public class Coords
    {
        public int CoordsID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}