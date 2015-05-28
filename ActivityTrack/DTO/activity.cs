using System;

namespace ActivityTrack.DTO
{
    public class activity
    {
        public int id { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset? endDate { get; set; }
        public string description { get; set; }
        public project project { get; set; }
    }
}