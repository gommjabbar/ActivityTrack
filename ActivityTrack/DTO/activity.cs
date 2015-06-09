using System;
using ActivityTrack.Models.IdEnums;

namespace ActivityTrack.DTO
{
    public class activity
    {
        public int id { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset? endDate { get; set; }
        public string description { get; set; }
        public ActivityStateIds activityState { get; set; }
        public int typeId { get; set; }
        public activityType type { get; set; }
        public int projectId { get; set; }
        public project project { get; set; }
    }
}