﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Walk.Models;
using System.Collections.Generic;

namespace Walk.Tests.Models
{
    [TestClass]
    public class FamilyTests
    {
        [TestMethod]
        public void FamilyEnsureICanCreateInstance()
        {
            Family a_family = new Family();
            Assert.IsNotNull(a_family);
        }

        [TestMethod]
        public void FamilyEnsureTheFamilyHasAllTheThings()
        {
            Family a_family = new Family();
            DateTime expected_time = DateTime.Now;
            a_family.FamilyId = 1;
            a_family.FamilyName = "Jones";
            a_family.Updated = expected_time;


            Assert.AreEqual(1, a_family.FamilyId);
            Assert.AreEqual("Jones", a_family.FamilyName);
            Assert.AreEqual(expected_time, a_family.Updated);

        }

        [TestMethod]
        public void FamilyEnsureICanUseObjectInitializerSyntax()
        {

            DateTime expected_time = DateTime.Now;
            Family a_family = new Family
            {
                FamilyId = 1,
                FamilyName = "Jones",
                Updated = expected_time
        };

            Assert.AreEqual(1, a_family.FamilyId);
            Assert.AreEqual("Jones", a_family.FamilyName);
            Assert.AreEqual(expected_time, a_family.Updated);

        }
    }
}
