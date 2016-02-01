using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Walk.Models;
using System.Collections.Generic;

namespace Walk.Tests.Models
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void GroupEnsureICanCreateInstance()
        {
            Group a_group = new Group();
            Assert.IsNotNull(a_group);
        }

        [TestMethod]
        public void GroupEnsureTheFamilyHasAllTheThings()
        {
            Group a_group = new Group();
            DateTime expected_time = DateTime.Now;

            a_group.GroupId = 1;
            a_group.GroupName = "St. Andrew";
            a_group.Updated = expected_time;
            a_group.Members = new List<Member> {
                new Member { FirstName = "Laura", LastName = "Rice", MemberId = 1 },
                new Member {FirstName = "Bernie", LastName = "Anderson", MemberId = 2 }
            };

            List<Member> ListMembers = new List<Member> {
                new Member { FirstName = "Laura", LastName = "Rice", MemberId = 1 },
                new Member {FirstName = "Bernie", LastName = "Anderson", MemberId = 2 }
            };


            Assert.AreEqual(1, a_group.GroupId);
            Assert.AreEqual("St. Andrew", a_group.GroupName);
            Assert.AreEqual("Laura", a_group.Members[0].FirstName);
            Assert.AreEqual(expected_time, a_group.Updated);

        }

        [TestMethod]
        public void GroupEnsureICanUseObjectInitializerSyntax()
        {

            DateTime expected_time = DateTime.Now;
            List<Member> ListMembers = new List<Member> {
                new Member { FirstName = "Laura", LastName = "Rice", MemberId = 1 },
                new Member {FirstName = "Bernie", LastName = "Anderson", MemberId = 2 }
            };

            
            Group a_group = new Group
            {
                GroupId = 1,
                GroupName = "St. Andrew",
                Members = ListMembers,
                Updated = expected_time
            };

            Assert.AreEqual(1, a_group.GroupId);
            Assert.AreEqual("St. Andrew", a_group.GroupName);
            Assert.AreEqual(ListMembers, a_group.Members);
            Assert.AreEqual(expected_time, a_group.Updated);

        }
    }
}
