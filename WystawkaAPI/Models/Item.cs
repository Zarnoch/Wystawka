using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WystawkaAPI.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateEnd { get; set; }
        public Foto Foto { get; set; }
        public Localization Localization { get; set; }
    }
}