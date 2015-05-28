using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActivityTrack.Controllers;
using ActivityTrack.DTO;

namespace ActivityTrack.IntegrationTests
{
    [TestClass]
    public class ActivitiesAPIControllerTests
    {
        [TestMethod]
        public void Add_ActivityWithoutProject_BadRequestReturned()
        {
            var controller = new ActivitiesAPIController();

            var result = controller.Add(new activity());

            
        }
    }
}
