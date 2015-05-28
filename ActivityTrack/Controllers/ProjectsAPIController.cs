using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ActivityTrack.DTO;
using ActivityTrack.Models;
using ActivityTrack.Repository;
using AutoMapper;

namespace ActivityTrack.Controllers
{
    public class ProjectsAPIController : ApiController
    {
        private IProjectEORepository _pr = new ProjectEORepository();

        [HttpGet]
        [Route("api/projects")]
        public IHttpActionResult GetAll()
        {
            Mapper.CreateMap<project, ProjectEO>();
            var allProjectsEO = _pr.Get();

            List<project> allProjectsDTO = allProjectsEO.Select(Mapper.Map<project>).ToList();

            return Json(allProjectsDTO);
        }

        [HttpGet]
        [Route("api/projects/{id}")]
        public IHttpActionResult Get(int id)
        {
            var projectEO = _pr.GetById(id);
            var projectDTO = Mapper.Map<project>(projectEO);

            return Json(projectDTO);
        }

        [HttpPost]
        [Route("api/projects")]
        public IHttpActionResult Add(project projectDTO)
        {
            var projectEO = Mapper.Map<ProjectEO>(projectDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pr.Insert(projectEO);
            return Json(projectDTO);
        }

        [HttpPut]
        [Route("api/projects")]
        public IHttpActionResult Update(int id, project projectDTO)
        {
            var projectEO = Mapper.Map<ProjectEO>(projectDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectEO.Id)
            {
                return BadRequest();
            }

            _pr.Update(projectEO);

            return Json(projectDTO);
        }

    }
}