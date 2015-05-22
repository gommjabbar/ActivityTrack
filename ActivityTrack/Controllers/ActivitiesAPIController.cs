using ActivityTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivityTrack.Controllers
{
    public class ActivitiesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/projects/{projectId}/activities")]
        public IHttpActionResult Get(int projectId)
        {
            var result = db.Activities
                .Where(activity => activity.ProjectId == projectId)
                .ToList();

            //TODO return all projects
            return Json(result);
        }
    }
}
