using System;
using System.Collections.Generic;
using System.Linq;
using ActivityTrack.Models;
using System.Web.Http;
using ActivityTrack.Repository;
using ActivityTrack.DTO;
using AutoMapper;

namespace ActivityTrack.Controllers
{
    public class ActivitiesAPIController : ApiController
    {
        private IActivityEORepository _activityRepository = new ActivityEORepository();
        private ITimeEORepository _timeRepository = new TimeEORepository();

        /// <summary>
        /// This method will return all activities. If there are no activities an empty page will be returned.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/activities")]
        public JsonNamedCollectionResponse<activity> GetAll()
        {
            return new JsonNamedCollectionResponse<activity>(Request, () =>
                {
                    var activitiesEO = _activityRepository.Get();

                    return activitiesEO.Select(Mapper.Map<activity>).ToList();

                },"activities");
            
        }


        /// <summary>
        /// This method will return all activities of project with given id
        /// If the project doesn't have activities the method will return BadRequest with message "project has no activities"
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/projects/{projectId}/activities")]
        public IHttpActionResult GetActivitiesOfProject(int projectId)
        {
            var activitiesEO = _activityRepository.ProjectActivities(projectId);

            List<activity> activitiesDTO = activitiesEO.Select(Mapper.Map<activity>).ToList();

            if (activitiesDTO.Count == 0)
            {
                return BadRequest("no activities for project with id "+projectId);
            }

            return Json(activitiesDTO);
        }


        /// <summary>
        /// This method will return the activity with given id.
        /// If there are no activity with this id the method will return BadRequest with message "no activity with given id"
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/activities/{activityId}")]
        public IHttpActionResult GetActivity(int activityId)
        {
            var activityEO = _activityRepository.GetById(activityId);

            if (activityEO == null)
            {
                return BadRequest("no project with given id " + activityId);
            }

            var activityDTO = Mapper.Map<activity>(activityEO);

            return Json(activityDTO);
        }


        /// <summary>
        /// This method will return all activities that has id between [offset; offset+length)
        /// If there are no activities maching, the method will return BadRequest with message "no activities with id between [offset; offset+length)"
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/activities")]
        public IHttpActionResult GetFromTo(int offset, int length)
        {
            var activitiesEO = _activityRepository.GetFromTo(offset, length);

            List<activity> activitiesDTO = activitiesEO.Select(Mapper.Map<activity>).ToList();

            if (activitiesDTO.Count == 0)
            {
                return BadRequest("no activities with id between ["+offset+"; "+(offset+length)+")");
            }

            return Json(activitiesDTO);
        }


        /// <summary>
        /// This method will add a new given activity in database
        /// If given activity is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="activityDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/activities")]
        public IHttpActionResult Add(activity activityDTO)
        {
            ActivityEO activityEO = Mapper.Map<ActivityEO>(activityDTO);

            if (activityEO.ProjectId == 0)
            {
                activityEO.ProjectId = activityEO.Project.Id;
                activityEO.Project = null;
            }
 
            activityEO.ActivityState = Models.IdEnums.ActivityStateIds.New;

            if (!ModelState.IsValid)
            {
                 return BadRequest(ModelState);
            }
            
            _activityRepository.Insert(activityEO);

            return Json(activityDTO);
        }

        /// <summary>
        /// This method will update the given activity as parametter, setting state to Started
        /// If given activity is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="activityDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/activities/start")]
        public IHttpActionResult StartActivity(activity activityDTO)
        {
            var activityEO = _activityRepository.Get().ToList().First(a => a.Id == activityDTO.id);

            if (activityEO.ActivityState != Models.IdEnums.ActivityStateIds.Started)
            {

                activityEO.ActivityState = Models.IdEnums.ActivityStateIds.Started;

                _activityRepository.Update(activityEO);

                var time = new TimeEO();
                time.StartDate = DateTimeOffset.Now;
                time.ActivityId = activityEO.Id;

                _timeRepository.Insert(time);

                return Json(activityDTO);
            }
            return BadRequest();
        }


        /// <summary>
        /// This method will update the given activity as parametter, setting state to Paused
        /// If given activity is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="activityDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/activities/pause")]
        public IHttpActionResult PauseActivity(activity activityDTO)
        {
            var activityEO = _activityRepository.Get().ToList().First(a => a.Id == activityDTO.id);

            if (activityEO.ActivityState == Models.IdEnums.ActivityStateIds.Started)
            {
                var last = _timeRepository.Get().ToList().Last(time => time.ActivityId == activityEO.Id);
                last.EndDate = DateTimeOffset.Now;
                _timeRepository.Update(last);

                activityEO.UpdateDate = DateTimeOffset.Now;
                activityEO.ActivityState = Models.IdEnums.ActivityStateIds.Paused;
                activityEO.ElapsedTime = _timeRepository.ElapsedTimeById(activityEO.Id);
                _activityRepository.Update(activityEO);

                return Json(activityDTO);
            }
            return BadRequest();
        }


        /// <summary>
        /// This method will update the given activity as parametter, setting state to Ended
        /// If given activity is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="activityDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/activities/end")]
        public IHttpActionResult EndActivity(activity activityDTO)
        {
            var activityEO = _activityRepository.Get().ToList().First(a => a.Id == activityDTO.id);

            if (activityEO.ActivityState == Models.IdEnums.ActivityStateIds.Started)
            {
                var last = _timeRepository.Get().ToList().Last(time => time.ActivityId == activityEO.Id);

                last.EndDate = DateTimeOffset.Now;

                _timeRepository.Update(last);

                activityEO.ElapsedTime = _timeRepository.ElapsedTimeById(activityEO.Id);
            }

            if (activityEO.ActivityState != Models.IdEnums.ActivityStateIds.Ended)
            {

                activityEO.ActivityState = Models.IdEnums.ActivityStateIds.Ended;

                _activityRepository.Update(activityEO);

                return Json(activityDTO);
            }

            return BadRequest();
        }

        /// <summary>
        /// This method will update the given activity as parametter.
        /// If given activity is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="activityDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/activities")]
        public IHttpActionResult Update(activity activityDTO)
        {
            var activityEO = Mapper.Map<ActivityEO>(activityDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _activityRepository.Update(activityEO);
            
            return Json(activityDTO);
        }
    }
}
