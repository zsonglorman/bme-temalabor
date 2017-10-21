using System;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PoseidonTests
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void GetSubjects_Mock()
        {
            // create mocking data access
            Mocks.Factory.DataAccessFactory.Mocking = true;
            var dataAccess = Mocks.Factory.DataAccessFactory.GetDataAccess();

            // get subjects with data access
            List<Subject> subjects = dataAccess.GetSubjects();

            // check whether we successfully received 2 subjects
            Assert.AreEqual(subjects.Count, 2);
        }

        [TestMethod]
        public void GetSubjects_Api()
        {
            // create web API data access
            Mocks.Factory.DataAccessFactory.Mocking = false;
            var dataAccess = Mocks.Factory.DataAccessFactory.GetDataAccess();

            // get subjects with data access
            List<Subject> subjects = dataAccess.GetSubjects();

            // check whether we successfully received 2 subjects
            Assert.AreEqual(subjects.Count, 2);
        }
    }
}
