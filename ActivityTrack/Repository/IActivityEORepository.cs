using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public interface IActivityEORepository: IGenericRepository<ActivityEO>
    { 
        List<ActivityEO> GetFromTo(int offset, int length);
        List<ActivityEO> ProjectActivities(int projectId);
    }
}