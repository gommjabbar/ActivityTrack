using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTrack.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ActivityEO> Activities { get; set; }
    }
}