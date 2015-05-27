using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository()
        {
            this.context = new ApplicationDbContext();
        }
        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Project>();
        }
    }
}