using System.Web.Http;
using ActivityTrack.Models;
using ActivityTrack.Repository;

namespace ActivityTrack.Controllers
{
    public class ProjectsAPIController : ApiController
    {
        private IProjectRepository _pr = new ProjectRepository();

        [HttpGet]
        [Route("api/projects")]
        public IHttpActionResult GetAll()
        {
            var result = _pr.Get();
            return Json(result);
        }

        [HttpGet]
        [Route("api/projects/{id}")]
        public IHttpActionResult Get(int id)
        {
            var result = _pr.GetById(id);
            return Json(result);
        }

        [HttpPost]
        [Route("api/projects")]
        public IHttpActionResult Add(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pr.Insert(project);
            return Json(project);
        }

        [HttpPut]
        [Route("api/projects")]
        public IHttpActionResult Update(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            _pr.Update(project);

            return Json(project);
        }

    }
}