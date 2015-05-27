using System.Collections.Generic;
using System.Linq;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ActivityRepository: GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository()
        {
            Context = new ApplicationDbContext();
        }
        public ActivityRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<Activity>();
        }

        public List<Activity> GetFromTo(int offset, int length)
        {
            var result = DbSet
                .Where(activity => activity.ProjectId >= offset && activity.ProjectId < offset + length)
                .ToList();
            return result;
        }

        public List<Activity> ProjectActivities(int projectId)
        {
            var result = DbSet
                .Where(activity => activity.ProjectId == projectId)
                .ToList();
            return result;
        }
    }
}