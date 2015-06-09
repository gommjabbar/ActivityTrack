using ActivityTrack.Models.IdEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTrack.Models
{
    [Table("Activities")]
    public class ActivityEO: BaseEntity
    {
        public int Id { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }

        public ActivityStateIds ActivityState { get; set; }

        public int? ActivityTypeId { get; set; }

        public virtual ActivityTypeEO ActivityType { get; set; }

        public int ProjectId { get; set; }

        public virtual ProjectEO Project { get; set; }

        public double ElapsedTime { get; set; }

        public virtual ICollection<TimeEO> ActivityTimes { get; set; }

        public ActivityEO()
        {
            ElapsedTime = 0;
        }
    }
}