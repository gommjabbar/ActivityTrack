using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class TimeEORepository : GenericRepository<TimeEO>, ITimeEORepository
    {
        public TimeEORepository()
        {
            Context = new ApplicationDbContext();
        }
        public TimeEORepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public double ElapsedTimeById(int id)
        {
            double counter = 0;

            var AllTimesById = Get().ToList().Where(time => time.ActivityId == id);

            foreach (var time in AllTimesById)
            {
                TimeSpan difference = (time.EndDate ?? DateTimeOffset.Now) -time.StartDate;

                counter = counter + difference.TotalMinutes;
            }
            return counter;
        }
    }
}