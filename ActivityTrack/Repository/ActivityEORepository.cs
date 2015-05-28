using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ActivityEORepository: GenericRepository<ActivityEO>, IActivityEORepository
    {
        public ActivityEORepository()
        {
            Context = new ApplicationDbContext();
        }
        public ActivityEORepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<ActivityEO> GetFromTo(int offset, int length)
        {
            // Return a list of activities that have id between "offset" and "offset"+"length"
            // Shortly, extracts first "length" activities starting from "offset"

            var result = Context.Set<ActivityEO>()
                .Where(activity => activity.ProjectId >= offset && activity.ProjectId < offset + length)
                .ToList();
            return result;
        }

        public List<ActivityEO> ProjectActivities(int projectId)
        {
            //Return a list of activities of specific project with id projectId

            var result = Context.Set<ActivityEO>()
                .Where(activity => activity.ProjectId == projectId)
                .ToList();
            return result;
        }
    }
}