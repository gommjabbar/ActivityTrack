using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityTrack.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ActivityDescription { get; set; }
        public int ActivtyTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public IEnumerable<SelectListItem> TypesList { get; set; }
    }
}