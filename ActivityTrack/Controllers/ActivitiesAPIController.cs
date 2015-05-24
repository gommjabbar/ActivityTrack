using ActivityTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

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
            return Json(result);
        }

        [HttpGet]
        [Route("api/activities?offset&length")]
        public IHttpActionResult GetFromTo(int offset, int length)
        {
            var result = db.Activities
                .Where(activity => activity.ProjectId >= offset && activity.ProjectId < offset+length)
                .ToList();
            return Json(result);
        }

        [HttpPost]
        [Route("api/activities")]
        public IHttpActionResult Add(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);
            db.SaveChanges();
            return Json(activity);
        }

        [HttpPut]
        [Route("api/activities")]
        public IHttpActionResult Update(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.Id)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Json(activity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.Id == id) > 0;
        }
    }
}
