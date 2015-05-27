using System.Collections.Generic;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    public interface IActivityRepository: IGenericRepository<Activity>
    {
        // Return a list of activities that have id between "offset" and "offset"+"length"
        // Shortly, extracts first "length" activities starting from "offset"
        List<Activity> GetFromTo(int offset, int length);

        //Return a list of activities of specific project with id projectId
        List<Activity> ProjectActivities(int projectId);
    }
}