using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Walk.Models;
using System.Collections.Generic;

namespace Walk.Tests.Models
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void MemberEnsureICanCreateInstance()
        {
            Member a_member = new Member();
            Assert.IsNotNull(a_member);
        }

        [TestMethod]
        public void MemberEnsureActivityHasAllTheThings()
        {
            Member a_member = new Member();
            DateTime expected_time = DateTime.Now;
            List<Activities> ListActivities =
               new List<Activities> {
                    new Activities {
                    ActivityId = 1,
                    Member = null,
                    ActivityName = "run",
                    Distance = 2.2,
                    Date = expected_time
                },
                    new Activities {
                    ActivityId = 2,
                    Member = null,
                    ActivityName = "walk",
                    Distance = 5.2,
                    Date = expected_time
                }
               };

            a_member.MemberId = 1;
            a_member.Family = null;
            a_member.Name = "Joe";
            a_member.Updated = expected_time;
            a_member.Activities = ListActivities;

            Assert.AreEqual(1, a_member.MemberId);
            Assert.AreEqual("Joe", a_member.Name);
            Assert.AreEqual(null, a_member.Family);
            Assert.AreEqual(ListActivities, a_member.Activities);
            Assert.AreEqual(expected_time, a_member.Updated);
        }

        [TestMethod]
        public void MemberEnsureICanUseObjectInitializerSyntax()
        {
           
            DateTime expected_time = DateTime.Now;
            List<Activities> ListActivities =
               new List<Activities> {
                    new Activities {
                    ActivityId = 1,
                    Member = null,
                    ActivityName = "run",
                    Distance = 2.2,
                    Date = expected_time
                },
                    new Activities {
                    ActivityId = 2,
                    Member = null,
                    ActivityName = "walk",
                    Distance = 5.2,
                    Date = expected_time
                }
               };
            Member a_member = new Member
            {
                MemberId = 1,
                Family = null,
                Name = "Joe",
                Updated = expected_time,
                Activities = ListActivities
            };
            Assert.AreEqual(1, a_member.MemberId);
            Assert.AreEqual("Joe", a_member.Name);
            Assert.AreEqual(null, a_member.Family);
            Assert.AreEqual(ListActivities, a_member.Activities);
            Assert.AreEqual(expected_time, a_member.Updated);
        }
    }
}
