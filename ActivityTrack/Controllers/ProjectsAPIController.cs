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

        /// <summary>
        /// This method will return all projects. If there are no projects an empty page will be returned.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/projects")]
        public IHttpActionResult GetAll()
        {
            var allProjectsEO = _pr.Get();

            List<project> allProjectsDTO = allProjectsEO.Select(Mapper.Map<project>).ToList();

            return Json(allProjectsDTO);
        }


        /// <summary>
        /// This method will return the project with given id.
        /// If there are no project with this id the method will return BadRequest with message "no project with given id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/projects/{id}")]
        public IHttpActionResult Get(int id)
        {
            var projectEO = _pr.GetById(id);

            if (projectEO == null)
            {
                return BadRequest("no project with given id "+id);
            }
            var projectDTO = Mapper.Map<project>(projectEO);

            return Json(projectDTO);
        }


        /// <summary>
        /// This method will add a new given project in database
        /// If given project is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method will update the given project as parametter.
        /// If given project is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/projects")]
        public IHttpActionResult Update(project projectDTO)
        {
            var projectEO = Mapper.Map<ProjectEO>(projectDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pr.Update(projectEO);

            return Json(projectDTO);
        }

    }
}