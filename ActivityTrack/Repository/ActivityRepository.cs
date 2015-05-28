using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ActivityRepository: GenericRepository<ActivityEO>, IActivityRepository
    {
        public ActivityRepository()
        {
            Context = new ApplicationDbContext();
        }
        public ActivityRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<ActivityEO>();
        }

        public List<ActivityEO> GetFromTo(int offset, int length)
        {
            // Return a list of activities that have id between "offset" and "offset"+"length"
            // Shortly, extracts first "length" activities starting from "offset"

            var result = DbSet
                .Where(activity => activity.ProjectId >= offset && activity.ProjectId < offset + length)
                .ToList();
            return result;
        }

        public List<ActivityEO> ProjectActivities(int projectId)
        {
            //Return a list of activities of specific project with id projectId

            var result = DbSet
                .Where(activity => activity.ProjectId == projectId)
                .ToList();
            return result;
        }
    }
}