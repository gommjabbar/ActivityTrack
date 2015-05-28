using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ActivityTrack.Models
{
    [Table("ActivityTypes")]
    public class ActivityTypeEO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ActivityEO> Activities { get; set; }
    }
}