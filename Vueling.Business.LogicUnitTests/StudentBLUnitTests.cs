﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.LogicUnitTests
{
    [TestClass]
    public class StudentBLUnitTests
    {
        private MockFactory _mockFactory;

        private Mock<ISelectDAO<Student>> _selectDaoStudentMock;
        private Mock<IInsertDAO<Student>> _insertDaoStudentMock;
        private Mock<IReadBL<Student>> _readBLStudentMock;
        private Mock<ISaveBL<Student>> _saveBLStudentMock;
        private Mock<IStudentBL> _studentBLMock;
        private DataTypeAccess _jsonType;
        private DataTypeAccess _xmlType;
        private DataTypeAccess _txtType;
        private DataTypeAccess _sqlType;

        private Student _studentStub;
        private Student _studentPresentationStub;
        private List<Student> _studentListStub;
        private DateTime _dateOfBirthStub;
        private DateTime _dateNow;

        [TestInitialize]
        public void Init()
        {
            _mockFactory = new MockFactory();
            _selectDaoStudentMock = _mockFactory.CreateMock<ISelectDAO<Student>>();
            _insertDaoStudentMock = _mockFactory.CreateMock<IInsertDAO<Student>>();
            _readBLStudentMock = _mockFactory.CreateMock<IReadBL<Student>>();
            _saveBLStudentMock = _mockFactory.CreateMock<ISaveBL<Student>>();
            _studentBLMock = _mockFactory.CreateMock<IStudentBL>();




            // Creating stubs
            _dateOfBirthStub = DateTime.Parse("25/02/1988");
            _dateNow = DateTime.Now;
            _studentPresentationStub = new Student()
            {
                Guid = Guid.NewGuid(),
                ID = 1,
                Nombre = "Carlos",
                Apellidos = "Sanchez Romero",
                DNI = "67676767Y",
                FechaDeNacimiento = DateTime.Parse("28/02/1988")
            };
            _studentStub = new Student(Guid.NewGuid(), 1, "Carlos", "Sanchez Romero", "67676767Y", DateTime.Parse("28/02/1988"), _dateNow, 30);
            _studentListStub = new List<Student>()
            {
                new Student(Guid.NewGuid(), 0, "Elisabet", "Bayot Bertran", "67676767Y", DateTime.Parse("27/05/1987"), DateTime.Now, 30)
            };
            _studentListStub.Add(_studentStub);
            _xmlType = DataTypeAccess.xml;
            _txtType = DataTypeAccess.txt;
            _sqlType = DataTypeAccess.sqlDB;
            _jsonType = DataTypeAccess.json;

            // Creating Expectations
            // ADD
            _insertDaoStudentMock.Expects
                .One
                .MethodWith(instance => instance.Add(_studentStub))
                .WillReturn(_studentStub);
            _saveBLStudentMock.Expects
                .One
                .MethodWith(instance => instance.Add(_studentStub))
                .WillReturn(_studentStub);
            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.Add(_studentStub))
                .WillReturn(_studentStub);

            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.Add(_studentStub))
                .WillReturn(_studentStub);

            // Calcualr edad
            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.CalcularEdad(_dateNow, _dateOfBirthStub))
                .WillReturn(30);

            //Get All
            _selectDaoStudentMock.Expects
                .Any
                .MethodWith(instance => instance.GetAll(_jsonType))
                .WillReturn(_studentListStub);
            _readBLStudentMock.Expects
                .Any
                .MethodWith(instance => instance.GetAll(_jsonType))
                .WillReturn(_studentListStub);
            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_jsonType))
                .WillReturn(_studentListStub);

            _selectDaoStudentMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_xmlType))
                .WillReturn(_studentListStub);
            _readBLStudentMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_xmlType))
                .WillReturn(_studentListStub);
            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_xmlType))
                .WillReturn(_studentListStub);

            _selectDaoStudentMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_txtType))
                .WillReturn(_studentListStub);
            _readBLStudentMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_txtType))
                .WillReturn(_studentListStub);
            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_txtType))
                .WillReturn(_studentListStub);


            _selectDaoStudentMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_sqlType))
                .WillReturn(_studentListStub);
            _readBLStudentMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_sqlType))
                .WillReturn(_studentListStub);
            _studentBLMock.Expects
                .One
                .MethodWith(instance => instance.GetAll(_sqlType))
                .WillReturn(_studentListStub);

        }

        [TestCleanup]
        public void End()
        {
            _mockFactory.ClearExpectations();
        }


        [TestMethod]
        public void AddUnitTestBL()
        {
            Assert.AreEqual(_studentStub, _studentBLMock.MockObject.Add(_studentStub));
        }

        [TestMethod]
        public void CalcularEdadUnitTest()
        {
            Assert.AreEqual(30, _studentBLMock.MockObject.CalcularEdad(_dateNow, _dateOfBirthStub));
        }

        [TestMethod]
        public void GetAllUnitTestJsonBL()
        {
            Assert.AreEqual(_studentListStub, _studentBLMock.MockObject.GetAll(_jsonType));
        }

        [TestMethod]
        public void GetAllUnitTestXmlBL()
        {
            Assert.AreEqual(_studentListStub, _studentBLMock.MockObject.GetAll(_xmlType));
        }

        [TestMethod]
        public void GetAllUnitTestTxtBL()
        {
            Assert.AreEqual(_studentListStub, _studentBLMock.MockObject.GetAll(_txtType));
        }

        [TestMethod]
        public void GetAllUnitTestSqlBL()
        {
            Assert.AreEqual(_studentListStub, _studentBLMock.MockObject.GetAll(_sqlType));
        }

    }
}
