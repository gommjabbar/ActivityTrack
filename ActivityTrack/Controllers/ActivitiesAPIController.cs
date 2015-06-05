﻿using System;
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
            var activityEO = Mapper.Map<ActivityEO>(activityDTO);

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
            return null;
        }

        [HttpPut]
        [Route("api/activities/pause")]
        public IHttpActionResult StartActivity(activity activityDTO)
        {
            return null;
        }
        [HttpPut]
        [Route("api/activities/end")]
        public IHttpActionResult StartActivity(activity activityDTO)
        {
            return null;
        }
        [HttpPut]
        [Route("api/activities")]
        public IHttpActionResult Update(int id, activity activityDTO)
        {
            var activityEO = Mapper.Map<ActivityEO>(activityDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityEO.Id)
            {
                return BadRequest();
            }

            _activityRepository.Update(activityEO);
            
            return Json(activityDTO);
        }
    }
}
