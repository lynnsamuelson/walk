using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Walk.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace Walk.Tests.Models
{
    [TestClass]
    public class WalkRepositoryTests
    {
        private Mock<WalkContext> mock_context;
        private Mock<DbSet<Group>> mock_group_set;
        private Mock<DbSet<Family>> mock_family_set;
        private Mock<DbSet<Member>> mock_member_set;
        private Mock<DbSet<Activities>> mock_activity_set;
        private ApplicationUser test_user;

        private WalkRepository repository;

        private void ConnectMocksToDataStore(IEnumerable<Group> data_store)
        {
            var data_source = data_store.AsQueryable<Group>();

            mock_group_set.As<IQueryable<Group>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_group_set.As<IQueryable<Group>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_group_set.As<IQueryable<Group>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_group_set.As<IQueryable<Group>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Group).Returns(mock_group_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Family> data_store)
        {
            var data_source = data_store.AsQueryable<Family>();

            mock_family_set.As<IQueryable<Family>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_family_set.As<IQueryable<Family>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Families).Returns(mock_family_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Member> data_store)
        {
            var data_source = data_store.AsQueryable<Member>();

            mock_member_set.As<IQueryable<Member>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_member_set.As<IQueryable<Member>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_member_set.As<IQueryable<Member>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_member_set.As<IQueryable<Member>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Members).Returns(mock_member_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<Activities> data_store)
        {
            var data_source = data_store.AsQueryable<Activities>();

            mock_activity_set.As<IQueryable<Activities>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_activity_set.As<IQueryable<Activities>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_activity_set.As<IQueryable<Activities>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_activity_set.As<IQueryable<Activities>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.Activities).Returns(mock_activity_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<WalkContext>();
            mock_group_set = new Mock<DbSet<Group>>();
            mock_family_set = new Mock<DbSet<Family>>();
            mock_member_set = new Mock<DbSet<Member>>();
            mock_activity_set = new Mock<DbSet<Activities>>();
            repository = new WalkRepository(mock_context.Object);
            test_user = new ApplicationUser { Email = "test5@example.com", Id = "myid-whoo" };
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_group_set = null;
            mock_family_set = null;
            mock_member_set = null;
            mock_activity_set = null;
            repository = null;
        }

        [TestMethod]
        public void WalkContextEnsureICanCreateInstance()
        {
            WalkContext context = new WalkContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void WalkRepositoryEnsureICanCreateInstance()
        {
            WalkRepository repository = new WalkRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void WalkRepositoryEnsureCanCreateRepository()
        {
            WalkRepository repository = new WalkRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void WalkRepositoryEnsureICanGetAllGroups()
        {
            var expected = new List<Group>
            {
                new Group {GroupName = "St. Andrew" },
                new Group {GroupName = "Fron" }
            };

            mock_group_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);


            var actual = repository.GetAllGroups();

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void WalkEnsureCanGetAllFamilies()
        {
            //Arrange
            var expected = new List<Family>
            {
                new Family {FamilyName = "Rice" },
                new Family {FamilyName = "Wade" }
            };
            mock_family_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            var actual = repository.GetAllFamilies();

            //Assert
            Assert.AreEqual("Rice", actual.First().FamilyName);
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void WalkContextEnsureCanGetAllMembers()
        {
            //Arrange
            var expected = new List<Member>
            {
                new Member {FirstName = "Joan" },
                new Member {FirstName = "Sally" }
            };
            mock_member_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            var actual = repository.GetAllMembers();

            //Assert
            Assert.AreEqual("Joan", actual.First().FirstName);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WalkContextEnsureCanGetAllActiviitis()
        {
            //Arrange
            var expected = new List<Activities>
            {
                new Activities {ActivityName = "walk", Distance = 1.1 },
                new Activities {ActivityName = "run", Distance = 3.2 },
                new Activities {ActivityName = "swim", Distance = 0.4 }

            };
            mock_activity_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            var actual = repository.GetAllActivities();

            //Assert
            Assert.AreEqual("walk", actual.First().ActivityName);
            Assert.AreEqual(1.1, actual.First().Distance);
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void WalkContextEnsureICanGetMemberById()
        {
            var expected = new List<Member> {
                new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie" },
                new Member {MemberId = 2, LastName = "Rice", FirstName = "Laura"}
            };
           
            mock_member_set.Object.AddRange(expected);
             ConnectMocksToDataStore(expected);
            Member Anderson = new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie" };
            Member actual = repository.GetMemberById(expected[0]);

            Assert.AreEqual("Anderson", actual.LastName);
        }


        [TestMethod]
        public void WalkContextEnsureCanGetMembersForAFamily()
        {
            var time = DateTime.Now;
            var family = new Family {FamilyName = "Anderson", FamilyId = 1, Updated = time};
            var family2 = new Family { FamilyName = "Anderson", FamilyId = 2, Updated =time};


            var member = new List<Member> {
                new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family, Updated = time },
                new Member {MemberId = 2, LastName = "Rice", FirstName = "Laura", Family = family2, Updated = time},
                new Member {MemberId = 3, LastName = "Anderson", FirstName = "Ruby", Family = family, Updated = time},
                new Member {MemberId = 4, LastName = "Rice", FirstName = "Adam", Family = family2, Updated = time},
                new Member {MemberId = 5, LastName = "Anderson", FirstName = "Samuel", Family = family, Updated = time},
                new Member {MemberId = 6, LastName = "Rice", FirstName = "Noah", Family = family2, Updated = time}
            };
            mock_member_set.Object.AddRange(member);
            ConnectMocksToDataStore(member);


            var testMember = new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family };
            var expectedMembers = new List<Member>
            {
                new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family, Updated = time },
                new Member {MemberId = 3, LastName = "Anderson", FirstName = "Ruby", Family = family, Updated = time},
                new Member {MemberId = 5, LastName = "Anderson", FirstName = "Samuel", Family = family, Updated = time}
            };
            var actual = repository.GetAllFamilyMembers(testMember);

            Assert.AreEqual("Bernie", actual.First().FirstName);
            Assert.AreEqual(expectedMembers[0].Family, actual[0].Family);
            Assert.AreEqual(expectedMembers[0].MemberId, actual[0].MemberId);
            Assert.AreEqual(expectedMembers[1].LastName, actual[1].LastName);
            Assert.AreEqual(expectedMembers[0].Group, actual[0].Group);
            Assert.AreEqual(expectedMembers[0].Updated, actual[0].Updated);
            //Assert.AreEqual(expectedMembers[0], actual[0]);

        }

        [TestMethod]
        public void WalkRepositoryEnsureCanGetMembersForAGroup()
        {
            var time = DateTime.Now;
            var family = new Family { FamilyName = "Anderson", FamilyId = 1, Updated = time };
            var family2 = new Family { FamilyName = "Anderson", FamilyId = 2, Updated = time };
            var group1 = new Group { GroupId = 1, GroupName = "St. Andrew" };
            var group2 = new Group { GroupId = 2, GroupName = "Fron" };
            

            var member = new List<Member> {
                new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family, Updated = time, Group
                 = group1},
                new Member {MemberId = 2, LastName = "Rice", FirstName = "Laura", Family = family2, Updated = time, Group = group2},
                new Member {MemberId = 3, LastName = "Anderson", FirstName = "Ruby", Family = family, Updated = time, Group = group1},
                new Member {MemberId = 4, LastName = "Rice", FirstName = "Adam", Family = family2, Updated = time, Group = group2},
                new Member {MemberId = 5, LastName = "Anderson", FirstName = "Samuel", Family = family, Updated = time, Group = group1},
                new Member {MemberId = 6, LastName = "Rice", FirstName = "Noah", Family = family2, Updated = time, Group = group2}
            };
            mock_member_set.Object.AddRange(member);
            ConnectMocksToDataStore(member);


            var testGroup = new Group { GroupId = 1, GroupName = "St. Andrew" };
            var expectedMembers = new List<Member>
            {
                 new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family, Updated = time, Group
                 = group1},
                new Member {MemberId = 3, LastName = "Anderson", FirstName = "Ruby", Family = family, Updated = time, Group = group1},
                new Member {MemberId = 5, LastName = "Anderson", FirstName = "Samuel", Family = family, Updated = time, Group = group1},
            };
            var actual = repository.GetAllGroupMembers(testGroup);

            Assert.AreEqual("Bernie", actual.First().FirstName);
            Assert.AreEqual(expectedMembers[0].Family, actual[0].Family);
            Assert.AreEqual(expectedMembers[0].MemberId, actual[0].MemberId);
            Assert.AreEqual(expectedMembers[1].LastName, actual[1].LastName);
            Assert.AreEqual(expectedMembers[0].Group, actual[0].Group);
            Assert.AreEqual(expectedMembers[0].Updated, actual[0].Updated);
            //Assert.AreEqual(expectedMembers[0], actual[0]);

        }

        [TestMethod]
        public void WalkRepositoryEnsureICanGetMembersActivities()
        {

            var time = DateTime.Now;
            var family = new Family { FamilyName = "Anderson", FamilyId = 1, Updated = time };
            var family2 = new Family { FamilyName = "Anderson", FamilyId = 2, Updated = time };
            var group1 = new Group { GroupId = 1, GroupName = "St. Andrew" };
            var group2 = new Group { GroupId = 2, GroupName = "Fron" };

            var members = new List<Member> {
                new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family, Updated = time, Group
                 = group1 },
                new Member { MemberId = 2, LastName = "Rice", FirstName = "Laura", Family = family2, Updated = time, Group = group2 },
                new Member { MemberId = 3, LastName = "Anderson", FirstName = "Ruby", Family = family, Updated = time, Group = group1 },
                new Member { MemberId = 4, LastName = "Rice", FirstName = "Adam", Family = family2, Updated = time, Group = group2 },
                new Member { MemberId = 5, LastName = "Anderson", FirstName = "Samuel", Family = family, Updated = time, Group = group1 },
                new Member { MemberId = 6, LastName = "Rice", FirstName = "Noah", Family = family2, Updated = time, Group = group2 }
            };

            mock_member_set.Object.AddRange(members);
            ConnectMocksToDataStore(members);

            var activities = new List<Activities>
            {
                new Activities {ActivityId = 1, ActivityName = "walking", Distance = 1.1d, Date = time, Participant =  members[0]},
                new Activities {ActivityId = 2, ActivityName = "run", Distance = 3.5d, Date = time, Participant =  members[3]},
                new Activities {ActivityId = 3, ActivityName = "swim", Distance = 8d, Date = time, Participant =  members[0] },
                new Activities {ActivityId = 4, ActivityName = "eliptical", Distance = 5d, Date = time, Participant =  members[1] },
                new Activities {ActivityId = 5, ActivityName = "swim", Distance = 6.3d, Date = time, Participant =  members[5]},
                new Activities {ActivityId = 6, ActivityName = "walking", Distance = 7.8d, Date = time, Participant =  members[2]  },
                new Activities {ActivityId = 7, ActivityName = "run", Distance = 12.4d, Date = time, Participant =  members[4] }
            };
            mock_activity_set.Object.AddRange(activities);
            ConnectMocksToDataStore(activities);

            Member Bernie = new Member
            {
                MemberId = 1,
                LastName = "Anderson",
                FirstName = "Bernie",
                Family = family,
                Updated = time,
                Group
                 = group1
            };
            Member Noah = new Member { MemberId = 6, LastName = "Rice", FirstName = "Noah", Family = family2, Updated = time, Group = group2 };

            Member actual = repository.GetMemberById(members[0]);
            var BernieActivities = repository.GetMembersActivities(Bernie);
            var NoahActivities = repository.GetMembersActivities(Noah);

            Assert.AreEqual("walking", BernieActivities.First().ActivityName);
            Assert.AreEqual("swim", BernieActivities[1].ActivityName);
            Assert.AreEqual("swim", NoahActivities.First().ActivityName);
            Assert.AreEqual(6.3d, NoahActivities[0].Distance);

        }

        [TestMethod]
        public void WalkRepositoryGetGroupsActivities()
        {
            var time = DateTime.Now;
            var family = new Family { FamilyName = "Anderson", FamilyId = 1, Updated = time };
            var family2 = new Family { FamilyName = "Anderson", FamilyId = 2, Updated = time };

            var groups = new List<Group>
            {
                new Group { GroupId = 1, GroupName = "St. Andrew" },
                new Group { GroupId = 2, GroupName = "Fron" }
            };
            mock_group_set.Object.AddRange(groups);
            ConnectMocksToDataStore(groups);

            var members = new List<Member> {
                new Member { MemberId = 1, LastName = "Anderson", FirstName = "Bernie", Family = family, Updated = time, Group
                 = groups[0] },
                new Member { MemberId = 2, LastName = "Rice", FirstName = "Laura", Family = family2, Updated = time, Group = groups[0] },
                new Member { MemberId = 3, LastName = "Anderson", FirstName = "Ruby", Family = family, Updated = time, Group = groups[0] },
                new Member { MemberId = 4, LastName = "Rice", FirstName = "Adam", Family = family2, Updated = time, Group = groups[1] },
                new Member { MemberId = 5, LastName = "Anderson", FirstName = "Samuel", Family = family, Updated = time, Group = groups[1] },
                new Member { MemberId = 6, LastName = "Rice", FirstName = "Noah", Family = family2, Updated = time, Group = groups[1] }
            };

            mock_member_set.Object.AddRange(members);
            ConnectMocksToDataStore(members);

            var activities = new List<Activities>
            {
                new Activities {ActivityId = 1, ActivityName = "walking", Distance = 1.1d, Date = time, Participant =  members[0]},
                new Activities {ActivityId = 2, ActivityName = "run", Distance = 3.5d, Date = time, Participant =  members[3]},
                new Activities {ActivityId = 3, ActivityName = "swim", Distance = 8d, Date = time, Participant =  members[0] },
                new Activities {ActivityId = 4, ActivityName = "eliptical", Distance = 5d, Date = time, Participant =  members[1] },
                new Activities {ActivityId = 5, ActivityName = "swim", Distance = 6.3d, Date = time, Participant =  members[5]},
                new Activities {ActivityId = 6, ActivityName = "walking", Distance = 7.8d, Date = time, Participant =  members[2]  },
                new Activities {ActivityId = 7, ActivityName = "run", Distance = 12.4d, Date = time, Participant =  members[4] }
            };
            mock_activity_set.Object.AddRange(activities);
            ConnectMocksToDataStore(activities);


            List<Activities> actualGroupActivities = repository.GetGroupActivities(groups[0]);
            var group1 = new Group { GroupId = 1, GroupName = "St. Andrew" };
            var group2 = new Group { GroupId = 2, GroupName = "Fron" };
            var group1Activities = new List<Activities>
            {
                new Activities {ActivityId = 1, ActivityName = "walking", Distance = 1.1d, Date = time, Participant =  members[0]},
                new Activities {ActivityId = 3, ActivityName = "swim", Distance = 8d, Date = time, Participant =  members[0] },
                new Activities {ActivityId = 4, ActivityName = "eliptical", Distance = 5d, Date = time, Participant =  members[1] },
                new Activities {ActivityId = 6, ActivityName = "walking", Distance = 7.8d, Date = time, Participant =  members[2]  }
            };

            Assert.AreEqual(1.1d, actualGroupActivities[0].Distance);

        }

        [TestMethod]
        public void WalkEnsureICanCreateAGroup()
        {
            // Arrange
            List<Group> expected_groups = new List<Group>(); 
            ConnectMocksToDataStore(expected_groups);
            Member Member1 = new Member { LastName = "Rice" };
            string groupName = "St Andrew";
            mock_group_set.Setup(j => j.Add(It.IsAny<Group>())).Callback((Group s) => expected_groups.Add(s));
            // Act
            bool successful = repository.CreateGroup(Member1, groupName);

            // Assert
            Assert.AreEqual(1, repository.GetAllGroups().Count);

        }

        [TestMethod]
        public void WalkEnsureICanCreateAMember()
        {
            // Arrange
            DateTime base_time = DateTime.Now;
            List<Member> expected_members = new List<Member>();
            ConnectMocksToDataStore(expected_members);
            Family family1 = new Family { FamilyName = "Rice", Updated = base_time };
            Group group1 = new Group { GroupName = "St. Andrew" };
            string firstName = "Laura";
            string lastName = "Rice";
            
            mock_member_set.Setup(j => j.Add(It.IsAny<Member>())).Callback((Member s) => expected_members.Add(s));
            // Act
            bool successful = repository.CreateMember(firstName, lastName, family1, group1);

            // Assert
            Assert.AreEqual(1, repository.GetAllMembers().Count);

        }

        [TestMethod]
        public void WalkEnsureICanCreateAFamily()
        {
            List<Family> expected_families = new List<Family>();
            ConnectMocksToDataStore(expected_families);
            string familyName = "Rice";
            mock_family_set.Setup(j => j.Add(It.IsAny<Family>())).Callback((Family s) => expected_families.Add(s));
            bool successful = repository.CreateFamily(familyName);

            Assert.AreEqual(1, repository.GetAllFamilies().Count);
        }

        [TestMethod]
        public void WalkEnsureICanCrateAnActivity()
        {
            List<Activities> expected_activities = new List<Activities>();
            ConnectMocksToDataStore(expected_activities);
            string activityName = "walk";
            double distance = 1.1d;
            Member member1 = new Member { LastName = "Rice" };
            mock_activity_set.Setup(j => j.Add(It.IsAny<Activities>())).Callback((Activities s) => expected_activities.Add(s));
            bool successful = repository.CreateActivity(activityName, distance, member1);

            Assert.AreEqual(1, repository.GetAllActivities().Count);
        }
    
    }
}



