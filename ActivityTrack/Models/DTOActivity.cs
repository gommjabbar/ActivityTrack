using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTrack.Models
{
    public class DTOActivity
    {
        public int id { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string description { get; set; }
        public int typeid { get; set; }
        public int projectid { get; set; }
    }
}