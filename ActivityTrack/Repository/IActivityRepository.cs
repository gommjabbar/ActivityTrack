using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public interface IActivityRepository: IGenericRepository<Activity>
    { 
        List<Activity> GetFromTo(int offset, int length);
        List<Activity> ProjectActivities(int projectId);
    }
}