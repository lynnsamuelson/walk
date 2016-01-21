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
            List<Member> ListMembers =
               new List<Member> {
                    new Member {
                    MemberId = 1,
                    Name = "Joe",
                    Updated = expected_time,

                },
                    new Member {
                    MemberId = 2,
                    Name = "Sally",
                    Updated = expected_time
                }
               };

            List<Family> ListFamilies =
               new List<Family> {
                   new Family
                   {
                    FamilyId = 1,
                    FamilyName = "Jones",
                    Members = ListMembers,
                    Group = null,
                    Updated = expected_time
                   },
                   new Family
                   {
                    FamilyId = 2,
                    FamilyName = "Anderson",
                    Members = ListMembers,
                    Group = null,
                    Updated = expected_time
                   }
               };


            a_group.GroupId = 1;
            a_group.GroupName = "St. Andrew";
            a_group.Updated = expected_time;
            a_group.Families = ListFamilies;


            Assert.AreEqual(1, a_group.GroupId);
            Assert.AreEqual("St. Andrew", a_group.GroupName);
            Assert.AreEqual(ListFamilies, a_group.Families);
            Assert.AreEqual(expected_time, a_group.Updated);

        }

        [TestMethod]
        public void GroupEnsureICanUseObjectInitializerSyntax()
        {

            DateTime expected_time = DateTime.Now;
            List<Member> ListMembers =
               new List<Member> {
                    new Member {
                    MemberId = 1,
                    Name = "Joe",
                    Updated = expected_time,

                },
                    new Member {
                    MemberId = 2,
                    Name = "Sally",
                    Updated = expected_time
                }
               };

            List<Family> ListFamilies =
               new List<Family> {
                   new Family
                   {
                    FamilyId = 1,
                    FamilyName = "Jones",
                    Members = ListMembers,
                    Group = null,
                    Updated = expected_time
                   },
                   new Family
                   {
                    FamilyId = 2,
                    FamilyName = "Anderson",
                    Members = ListMembers,
                    Group = null,
                    Updated = expected_time
                   }
               };
            Group a_group = new Group
            {
                GroupId = 1,
                GroupName = "St. Andrew",
                Families = ListFamilies,
                Updated = expected_time
            };

            Assert.AreEqual(1, a_group.GroupId);
            Assert.AreEqual("St. Andrew", a_group.GroupName);
            Assert.AreEqual(ListFamilies, a_group.Families);
            Assert.AreEqual(expected_time, a_group.Updated);

        }
    }
}
