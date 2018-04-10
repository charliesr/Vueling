using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;

namespace Vueling.DataAccess.DAOUnitTests
{
    [TestClass]
    public class StudentDAOUnitTest
    {
        private MockFactory _mockFactory;
        [TestInitialize]
        public void Init()
        {
            _mockFactory = new MockFactory();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
