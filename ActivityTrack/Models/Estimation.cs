using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTrack.Models
{
    public class Estimation: BaseEntity
    {
        public double EstimatedEffort { get; set; }
        public DateTimeOffset? EstimatedStartDate { get; set; }
    }
}