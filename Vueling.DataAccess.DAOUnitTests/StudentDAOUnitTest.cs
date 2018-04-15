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
    public class StudentDAOUnitTest
    {
        private MockFactory _mockFactory;
        private Mock<ISelectDAO<Student>> _selectDAO;
        private Mock<IInsertDAO<Student>> _insertDAO;
        private Mock<IFormat<Student>> _formatFactory;
        private Student _studentStub;
        private List<Student> _studentListStub;
        private DataTypeAccess _jsonType;
        private DataTypeAccess _xmlType;
        private DataTypeAccess _txtType;
        private DataTypeAccess _sqlType;
        private IFormat<Student> _factoryJsonStub;

        [TestInitialize]
        public void Init()
        {
            _mockFactory = new MockFactory();
            _insertDAO = _mockFactory.CreateMock<IInsertDAO<Student>>();
            _selectDAO = _mockFactory.CreateMock<ISelectDAO<Student>>();

            // Creating Stub
            _studentStub = new Student(Guid.NewGuid(), 1, "Carlos", "Sanchez Romero", "646464646Y", DateTime.Parse("28/02/1988"), DateTime.Now, 30);
            _studentListStub = new List<Student>()
            {
                new Student(Guid.NewGuid(),2,"Elisabet","Bayot Bertran","545454545T",DateTime.Parse("27/05/1987"),DateTime.Now,30)
            };
            _studentListStub.Add(_studentStub);
            _xmlType = DataTypeAccess.xml;
            _txtType = DataTypeAccess.txt;
            _sqlType = DataTypeAccess.sqlDB;
            _jsonType = DataTypeAccess.json;


            //Creating Expectations
            _selectDAO.Expects
                .One
                .MethodWith(instance => instance.GetAll(_xmlType))
                .WillReturn(_studentListStub);
            _selectDAO.Expects
                .One
                .MethodWith(instance => instance.GetAll(_sqlType))
                .WillReturn(_studentListStub);
            _selectDAO.Expects
                .One
                .MethodWith(instance => instance.GetAll(_jsonType))
                .WillReturn(_studentListStub);
            _selectDAO.Expects
                .One
                .MethodWith(instance => instance.GetAll(_txtType))
                .WillReturn(_studentListStub);

            _insertDAO.Expects
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
            Assert.AreEqual(_studentListStub, _selectDAO.MockObject.GetAll(_jsonType));
        }

        [TestMethod]
        public void GetAllXmlUnitTestDao()
        {
            Assert.AreEqual(_studentListStub, _selectDAO.MockObject.GetAll(_xmlType));
        }

        [TestMethod]
        public void GetAllTxtUnitTestDao()
        {
            Assert.AreEqual(_studentListStub, _selectDAO.MockObject.GetAll(_txtType));
        }

        [TestMethod]
        public void GetAllSqlUnitTestDao()
        {
            Assert.AreEqual(_studentListStub, _selectDAO.MockObject.GetAll(_sqlType));
        }

        [TestMethod]
        public void AddUnitTestDao()
        {
            Assert.AreEqual(_studentStub, _insertDAO.MockObject.Add(_studentStub));
        }
    }
}
