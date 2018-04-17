using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.DataAccess.DAOUnitTests
{
    [TestClass]
    public class StudentDaoUnitTest
    {
        private MockFactory _mockFactory;
        private Mock<ICrudDAO<Student>> _crudDao;
        private Student _studentStub;
        private List<Student> _studentListStub;

        [TestInitialize]
        public void Init()
        {
            _mockFactory = new MockFactory();
            _crudDao = _mockFactory.CreateMock<ICrudDAO<Student>>();

            // Creating Stub
            _studentStub = new Student(Guid.NewGuid(), 1, "Carlos", "Sanchez Romero", "646464646Y", DateTime.Parse("28/02/1988"), DateTime.Now, 30);
            _studentListStub = new List<Student>()
            {
                new Student(Guid.NewGuid(),2,"Elisabet","Bayot Bertran","545454545T",DateTime.Parse("27/05/1987"),DateTime.Now,30)
            };
            _studentListStub.Add(_studentStub);


            //Creating Expectations
            _crudDao.Expects
                .One
                .MethodWith(instance => instance.GetAll())
                .WillReturn(_studentListStub);
            _crudDao.Expects
                .One
                .MethodWith(instance => instance.Add(_studentStub))
                .WillReturn(_studentStub);
        }

        [TestCleanup]
        public void End()
        {
            _mockFactory.ClearExpectations();
        }

        [TestMethod]
        public void GetAllJsonUnitTestDao()
        {
            Assert.AreEqual(_studentListStub, _crudDao.MockObject.GetAll());
        }

        [TestMethod]
        public void AddUnitTestDao()
        {
            Assert.AreEqual(_studentStub, _crudDao.MockObject.Add(_studentStub));
        }
    }
}
