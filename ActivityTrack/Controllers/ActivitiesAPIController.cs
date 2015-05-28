using ActivityTrack.Models;
using System.Web.Http;
using ActivityTrack.Repository;
using ActivityTrack.DTO;
using AutoMapper;

namespace ActivityTrack.Controllers
{
    public class ActivitiesAPIController : ApiController
    {
        private IActivityRepository _ar = new ActivityRepository();

        [HttpGet]
        [Route("api/projects/{projectId}/activities")]
        public IHttpActionResult Get(int projectId)
        {
            var result = _ar.ProjectActivities(projectId);
            return Json(result);
        }
        [HttpGet]
        [Route("api/activities/{activityId}")]
        public IHttpActionResult GetActivity(int activityId)
        {
            var result = _ar.GetById(activityId);
            return Json(new { });
        }
        [HttpGet]
        [Route("api/activities")]
        public IHttpActionResult GetFromTo(int offset, int length)
        {
            var result = _ar.GetFromTo(offset, length);
            return Json(result);
        }

        [HttpPost]
        [Route("api/activities")]
        public IHttpActionResult Add(activity activity)
        {
            if (!ModelState.IsValid)
            {
                 return BadRequest(ModelState);
            }
            //var a = new ActivityEO();
            //a.ActivityDescription = activity.description;
            //_ar.Insert(activity);
            return Json(activity);
        }

        [HttpPut]
        [Route("api/activities")]
        public IHttpActionResult Update(int id, ActivityEO activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.Id)
            {
                return BadRequest();
            }

            _ar.Update(activity);
            
            return Json(activity);
        }
    }
}
