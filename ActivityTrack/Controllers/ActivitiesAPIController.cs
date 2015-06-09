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

        [HttpGet]
        [Route("api/activities")]
        public IHttpActionResult GetAll()
        {
            var activitiesEO = _activityRepository.Get();

            List<activity> activitiesDTO = activitiesEO.Select(Mapper.Map<activity>).ToList();

            return Json(activitiesDTO);
        }

        [HttpGet]
        [Route("api/projects/{projectId}/activities")]
        public IHttpActionResult GetActivitiesOfProject(int projectId)
        {
            var activitiesEO = _activityRepository.ProjectActivities(projectId);

            List<activity> activitiesDTO = activitiesEO.Select(Mapper.Map<activity>).ToList();

            return Json(activitiesDTO);
        }

        [HttpGet]
        [Route("api/activities/{activityId}")]
        public IHttpActionResult GetActivity(int activityId)
        {
            var activityEO = _activityRepository.GetById(activityId);

            var activityDTO = Mapper.Map<activity>(activityEO);

            return Json(activityDTO);
        }

        [HttpGet]
        [Route("api/activities")]
        public IHttpActionResult GetFromTo(int offset, int length)
        {
            var activitiesEO = _activityRepository.GetFromTo(offset, length);

            List<activity> activitiesDTO = activitiesEO.Select(Mapper.Map<activity>).ToList();

            return Json(activitiesDTO);
        }

        [HttpPost]
        [Route("api/activities")]
        public IHttpActionResult Add(activity activityDTO)
        {
            var activityEO = new ActivityEO();

            activityEO = Mapper.Map<ActivityEO>(activityDTO);

            activityEO.ActivityState = Models.IdEnums.ActivityStateIds.New;

            if (!ModelState.IsValid)
            {
                 return BadRequest(ModelState);
            }
            
            _activityRepository.Insert(activityEO);

            return Json(activityDTO);
        }

        
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
