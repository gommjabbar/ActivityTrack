using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTrack.Models
{
    [Table("Activities")]
    public class ActivityEO
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ActivityDescription { get; set; }

        [ForeignKey("ActivityType")]
        public int ActivtyTypeId { get; set; }
        public virtual ActivityTypeEO ActivityType { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public virtual ProjectEO Project { get; set; }

    }
}