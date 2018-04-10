using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.LogicUnitTests
{
    [TestClass]
    public class StudentBLTests
    {
        private MockFactory _mockFactory;
        private Mock<ISelectDAO<Student>> _crudReadStudent;
        private Mock<IInsertDAO<Student>> _crudSaveStudent;

        [TestInitialize]
        public void Init()
        {
            _mockFactory = new MockFactory();
            _crudReadStudent = _mockFactory.CreateMock<ISelectDAO<Student>>();
            _crudSaveStudent = _mockFactory.CreateMock<IInsertDAO<Student>>();
        }


        [TestMethod]
        public void CrudSaveAddTestBL()
        {
            var guidTest = Guid.NewGuid();
            var studentTest = new Student
            {
                Guid = guidTest,
                ID = 1,
                Nombre = "Carlos",
                Apellidos = "Sanchez Romero",
                DNI = "44445555T",
                FechaDeNacimiento = DateTime.Parse("28/02/1988"),
                Edad = 30
            };
            var studentReturnStub = (Student)studentTest.Clone();
            _crudSaveStudent.Expects.One.MethodWith(sm => sm.Add(studentTest)).WillReturn(studentReturnStub);

            var studentReturn = _crudSaveStudent.MockObject.Add(studentTest);

            Assert.IsTrue(studentTest.Equals(studentReturn));
           
        }
    }
}
