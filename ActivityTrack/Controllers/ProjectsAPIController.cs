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
        public JsonCollectionResponse<project> GetAll()
        {
            return new JsonCollectionResponse<project>(Request, () =>
            {
                var allProjectsEO = _pr.Get();

                return allProjectsEO.Select(Mapper.Map<project>).ToList();
            });
        }


        /// <summary>
        /// This method will return the project with given id.
        /// If there are no project with this id the method will return BadRequest with message "no project with given id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/projects/{id}")]
        public JsonResponse<project> Get(int id)
        {
            return new JsonResponse<project>(Request, () =>
            {
                var projectEO = _pr.GetById(id);

                return Mapper.Map<project>(projectEO);
            });
        }


        /// <summary>
        /// This method will add a new given project in database
        /// If given project is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/projects")]
        public JsonResponse<project> Add(project projectDTO)
        {
            return new JsonResponse<project>(Request, () =>
            {
                var projectEO = Mapper.Map<ProjectEO>(projectDTO);

                if (ModelState.IsValid)
                {
                    _pr.Insert(projectEO);
                }

                return Mapper.Map<project>(projectEO);
            });
        }

        /// <summary>
        /// This method will update the given project as parametter.
        /// If given project is not valid the method will return BadRequest(ModelState)
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/projects")]
        public JsonResponse<project> Update(project projectDTO)
        {
            return new JsonResponse<project>(Request, () =>
            {
                var projectEO = Mapper.Map<ProjectEO>(projectDTO);

                if (ModelState.IsValid)
                {
                    _pr.Update(projectEO);
                }

                return Mapper.Map<project>(projectEO);
            });
        }

    }
}