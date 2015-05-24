using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ActivityTrack.Models;

namespace ActivityTrack.Controllers
{
    public class ProjectsAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/projects")]
        public IHttpActionResult GetAll()
        {
            //TODO return all projects
            return Json(new { });
        }

        [HttpGet]
        [Route("api/projects/{id}")]
        public IHttpActionResult Get(int id)
        {
            //TODO return all projects
            return Json(new { });
        }

        //R: GET: api/projects/{id}

        [HttpGet]
        [Route("api/projects/{id}")]
        public IHttpActionResult GetProjectById(int projectId)
        {
            return Json(db.Projects.Find(projectId));
        }

        [HttpGet]
        [Route("api/projects")]
        public IHttpActionResult GettAll()
        {
            return Json(db.Projects.ToList());
        }


        [HttpPost]
        [Route("api/projects")]
        public IHttpActionResult Add(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }
            return Json(project);
        }


    }
}