using System;
using System.Diagnostics;
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
        public void Add_ActivityGoodData()
        {

            //succes -> return Json(activityDTO) 
            //fail -> return BadRequest(ModelState) -> something else than succes is considered fail

            var ctrl = new ActivitiesAPIController();

            //all fields completed
            var a1 = new activity();

            a1.id = 1;
            a1.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a1.description = "test";
            a1.activtyTypeId = 1;
            a1.projectId = 1;

            var result1 = ctrl.Add(a1);

            var test = JsonConvert.SerializeObject(a1);
            Debug.Assert(result1.ToString() == test);

            //just mandatory fields completed
            var a2 = new activity();

            a2.startDate = DateTimeOffset.Now;
            a2.description = "test";
            a2.activtyTypeId = 1;
            a2.projectId = 1;

            var result2 = ctrl.Add(a2);

            var test2 = JsonConvert.SerializeObject(a2);
            Debug.Assert(result2.ToString() == test2);

        }


        [TestMethod]
        public void Add_ActivityMissingData()
        {
            //succes -> return Json(activityDTO) 
            //fail -> return BadRequest(ModelState) -> something else than succes is considered fail

            var ctrl = new ActivitiesAPIController();


            //projectId has no value
            var a1 = new activity();

            a1.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a1.description = "test";
            a1.activtyTypeId = 1;

            var result1 = ctrl.Add(a1);

            var test1 = JsonConvert.SerializeObject(a1);
            Debug.Assert(result1.ToString() != test1);


            //activityTypeId has no value
            var a2 = new activity();

            a2.startDate = DateTimeOffset.Now;
            a1.endDate = DateTimeOffset.Now;
            a2.description = "test";
            a2.projectId = 1;

            var result2 = ctrl.Add(a1);

            var test2 = JsonConvert.SerializeObject(a1);
            Debug.Assert(result2.ToString() != test2);


            //projectId and ativityTypeId has no value
            var a3 = new activity();

            a3.startDate = DateTimeOffset.Now;
            a3.endDate = DateTimeOffset.Now;
            a3.description = "test";

            var result3 = ctrl.Add(a1);

            var test3 = JsonConvert.SerializeObject(a1);
            Debug.Assert(result3.ToString() != test3);
        }
    }
}
