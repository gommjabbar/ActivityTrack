using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ProjectEORepository: GenericRepository<ProjectEO>, IProjectEORepository
    {
        public ProjectEORepository()
        {
            Context = new ApplicationDbContext();
        }
        public ProjectEORepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<ProjectEO>();
        }
    }
}