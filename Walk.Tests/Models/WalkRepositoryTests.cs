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
                new Member {Name = "Joan" },
                new Member {Name = "Sally" }
            };
            mock_member_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            //Act
            var actual = repository.GetAllMembers();

            //Assert
            Assert.AreEqual("Joan", actual.First().Name);
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
    }
}
