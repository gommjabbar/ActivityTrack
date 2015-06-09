using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityTrack.Models;

namespace ActivityTrack.Repository
{
    interface ITimeEORepository:IGenericRepository<TimeEO>
    {
        double ElapsedTimeById(int id);
    }
}
