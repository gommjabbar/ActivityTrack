using System;

namespace ActivityTrack.DTO
{
    public class activity
    {
        public int id { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset? endDate { get; set; }
        public string description { get; set; }
        public int activtyTypeId { get; set; }
        public activityType qctivityType { get; set; }
        public int projectId { get; set; }
        public project project { get; set; }
    }
}