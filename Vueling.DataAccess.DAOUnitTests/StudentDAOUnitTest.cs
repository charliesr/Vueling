using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.DataAccess.DAOUnitTests
{
    [TestClass]
    public class StudentDAOUnitTest
    {
        private MockFactory _mockFactory;
        private Mock<ISelectDAO<Student>> _selectDAO;
        private Mock<IInsertDAO<Student>> _insertDAO;
        
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
