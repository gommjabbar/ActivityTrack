using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ActivityRepository: GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository()
        {
            this.context = new ApplicationDbContext();
        }
        public ActivityRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Activity>();
        }

        public List<Activity> GetFromTo(int offset, int length)
        {
            // Return a list of activities that have id between "offset" and "offset"+"length"
            // Shortly, extracts first "length" activities starting from "offset"

            var result = dbSet
                .Where(activity => activity.ProjectId >= offset && activity.ProjectId < offset + length)
                .ToList();
            return result;
        }

        public List<Activity> ProjectActivities(int projectId)
        {
            //Return a list of activities of specific project with id projectId

            var result = dbSet
                .Where(activity => activity.ProjectId == projectId)
                .ToList();
            return result;
        }
    }
}