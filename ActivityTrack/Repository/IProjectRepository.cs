using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> Get(Expression<Func<Project, bool>> filter = null, Func<IQueryable<Project>, IOrderedQueryable<Project>> orderBy = null, string includeProperties = "");
        Project GetByID(object id);
        void Insert(Project entity);
        void Delete(object id);
        void Delete(Project entityToDelete);
        void Update(Project entityToUpdate);
    }
}