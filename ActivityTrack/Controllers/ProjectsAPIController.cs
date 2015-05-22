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


        [HttpPost]
        [Route("api/projects")]
        public IHttpActionResult Add(Project project)
        {
            if (ModelState.IsValid)
            {
                if (project.Id < 0)
                    project.Id = 100;
                project.Name = "test";
            }
            return Json(project);
        }

        // POST: api/ProjectAPI
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE: api/ProjectAPI/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}