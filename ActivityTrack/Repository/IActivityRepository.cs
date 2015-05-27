using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> Get(Expression<Func<Activity, bool>> filter = null, Func<IQueryable<Activity>, IOrderedQueryable<Activity>> orderBy = null, string includeProperties = "");
        Activity GetByID(object id);
        void Insert(Activity entity);
        void Delete(object id);
        void Delete(Activity entityToDelete);
        void Update(Activity entityToUpdate);
        List<Activity> GetFromTo(int offset, int length);
        List<Activity> ProjectActivities(int projectId);
    }
}