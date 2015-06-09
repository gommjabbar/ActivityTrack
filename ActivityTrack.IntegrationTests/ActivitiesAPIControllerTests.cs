using System;
using System.Diagnostics;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActivityTrack.Controllers;
using ActivityTrack.DTO;
using Newtonsoft.Json;

namespace ActivityTrack.IntegrationTests
{
    [TestClass]
    public class ActivitiesAPIControllerTests
    {
        [TestMethod]
        public void GetAllActivities()
        {
            AutoMapperConfig.Configure();
            var ctrl = new ActivitiesAPIController();

            var result = ctrl.GetAll();

            Assert.IsNotInstanceOfType(result, typeof(BadRequestResult));

        }

        [TestMethod]
        public void Add_ActivityGoodData()
        {

            //succes -> return Json(activityDTO) 
            //fail -> return BadRequest(ModelState) -> something else than succes is considered fail

            AutoMapperConfig.Configure();
            var ctrl = new ActivitiesAPIController();

            //all fields completed
            var a1 = new activity();

            a1.id = 1;
            a1.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a1.description = "test";
            a1.typeId = 1;
            a1.projectId = 1;

            var result1 = ctrl.Add(a1);
       
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            //just mandatory fields completed
            var a2 = new activity();

            a2.startDate = DateTimeOffset.Now;
            a2.description = "test";
            a2.typeId = 1;
            a2.projectId = 1;

            var result2 = ctrl.Add(a2);

            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));

        }


        [TestMethod]
        public void Add_ActivityMissingData()
        {
            //succes -> return Json(activityDTO) 
            //fail -> return BadRequest(ModelState) -> something else than succes is considered fail

            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();

            //projectId has no value
            var a1 = new activity();
            a1.projectId = 1;
            a1.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a1.description = "test";
            //a1.typeId = 0;

            var result1 = ctrl.Add(a1);

            Assert.IsInstanceOfType(result1, typeof(BadRequestResult));

            /*
            //activityTypeId has no value
            var a2 = new activity();

            a2.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a2.description = "test";
            a2.projectId = 1;

            var result2 = ctrl.Add(a1);

            Assert.IsInstanceOfType(result2, typeof(BadRequestResult));


            //projectId and ativityTypeId has no value
            var a3 = new activity();

            a3.startDate = DateTimeOffset.Now;
            a3.endDate = DateTimeOffset.Now;
            a3.description = "test";

            var result3 = ctrl.Add(a1);

            Assert.IsNotInstanceOfType(result3, typeof(BadRequestResult));
             * */
        }

        [TestMethod]
        public void Get_ActivityWithDataResult()
        {
            //activity is found in db, so it has to be different from BadResult
            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();

            var result1 = ctrl.GetActivity(1);
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            var result2 = ctrl.GetActivity(2);
            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_ActivityNoDataResult()
        {
            //activity is not found in db, so it has to be BadResult
            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();

            var result1 = ctrl.GetActivity(15000);
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            var result2 = ctrl.GetActivity(16000);
            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_ActivitiesOfProjectWithDataResult()
        {
            //the project has some activities, si it has to be different from BadRequest
            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();

            var result1 = ctrl.GetActivitiesOfProject(1);
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            var result2 = ctrl.GetActivitiesOfProject(1);
            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_ActivitiesOfProjectNoDataResult()
        {
            //the project does not have activities, so it has to be BadRequest
            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();


            var result1 = ctrl.GetActivitiesOfProject(21000);
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            var result2 = ctrl.GetActivitiesOfProject(20000);
            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_ActivitiesFromToWithDataResult()
        {
            //there are some activities between offset and offset+length, so it has to be different from BadRequest
            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();


            var result1 = ctrl.GetFromTo(1,2);
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            var result2 = ctrl.GetFromTo(2,10);
            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_ActivitiesFromToNoDataResult()
        {
            //there are not activities between offset and offset+length, so it has to be BadRequest
            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();


            var result1 = ctrl.GetFromTo(10000, 2);
            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

            var result2 = ctrl.GetFromTo(12000, 1);
            Assert.IsNotInstanceOfType(result2, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Update_ActivityGoodData()
        {

            //succes -> return Json(activityDTO) 
            //fail -> return BadRequest(ModelState) -> something else than succes is considered fail

            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();


            //all fields completed and id coresponds with a1.id
            var a1 = new activity();

            a1.id = 3;
            a1.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a1.description = "test";
            a1.typeId = 1;
            a1.projectId = 1;

            var result1 = ctrl.Update(a1);

            Assert.IsNotInstanceOfType(result1, typeof(BadRequestResult));

        }

        [TestMethod]
        public void Update_ActivityIdDifferentFromActivityId()
        {


            var ctrl = new ActivitiesAPIController();
            AutoMapperConfig.Configure();


            //all fields completed and id does not corespond with a1.id -> BadRequest
            var a1 = new activity();

            a1.id = 2;
            a1.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a1.description = "test";
            a1.typeId = 1;
            a1.projectId = 1;

            var result1 = ctrl.Update(a1);

            Assert.IsInstanceOfType(result1, typeof(BadRequestResult));

        }
    }
}
