using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository()
        {
            Context = new ApplicationDbContext();
        }
        public ProjectRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<Project>();
        }
    }
}