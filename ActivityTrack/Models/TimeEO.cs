using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace ActivityTrack.Models
{
    [Table("Times")]
    public class TimeEO: BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public int ActivityId { get; set; }
        public virtual ActivityEO Activity { get; set; }
    }
}