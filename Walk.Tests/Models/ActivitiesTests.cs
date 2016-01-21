using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Walk.Models;

namespace Walk.Tests.Models
{
    [TestClass]
    public class ActivitiesTests
    {
        [TestMethod]
        public void ActivitiesEnsureICanCreateInstance()
        {
            Activities a_activity = new Activities();
            Assert.IsNotNull(a_activity);
        }

        [TestMethod]
        public void AcitivitiesEnsureActivityHasAllTheThings()
        {
            Activities a_activity = new Activities();

            DateTime expected_time = DateTime.Now;
            a_activity.ActivityId = 1;
            a_activity.Member = null;
            a_activity.ActivityName = "run";
            a_activity.Distance = 2.2;
            a_activity.Date = expected_time;

            Assert.AreEqual(1, a_activity.ActivityId);
            Assert.AreEqual("run", a_activity.ActivityName);
            Assert.AreEqual(null, a_activity.Member);
            Assert.AreEqual(2.2, a_activity.Distance);
            Assert.AreEqual(expected_time, a_activity.Date);
        }

        [TestMethod]
        public void ActivitiesEnsureICanUseObjectInitializerSyntax()
        {
            DateTime expected_time = DateTime.Now;
            Activities a_activity = new Activities
            {
                ActivityId = 1,
                Member = null,
                ActivityName = "run",
                Distance = 2.2,
                Date = expected_time
            };
            Assert.AreEqual(1, a_activity.ActivityId);
            Assert.AreEqual("run", a_activity.ActivityName);
            Assert.AreEqual(null, a_activity.Member);
            Assert.AreEqual(2.2, a_activity.Distance);
            Assert.AreEqual(expected_time, a_activity.Date);
        }
    }
}
