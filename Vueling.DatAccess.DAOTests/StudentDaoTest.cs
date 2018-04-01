using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Common.Logic.Model;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using Vueling.DataAccess.DAO;
using Vueling.Common.Logic;

namespace Vueling.DatAccess.DAOTests
{
    [TestClass]
    public class StudentDaoTest
    {
        private readonly string Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Student";
        private readonly IStudentDao StudentRepository = new StudentDao();
        [TestInitialize]
        public void InitTest()
        {
            if (File.Exists(Filename + ".json")) File.Delete(Filename + ".json");
            if (File.Exists(Filename + ".xml")) File.Delete(Filename + ".xml");
            if (File.Exists(Filename + ".txt")) File.Delete(Filename + ".txt");
        }

        [TestCleanup]
        public void CleanUp()
        {
            File.Delete(Filename + ".json");
            File.Delete(Filename + ".xml");
            File.Delete(Filename + ".txt");
        }


        public static IEnumerable<object[]> StudentData()
        {
            yield return new object[] { new Student(Guid.NewGuid(), 1, "Carlos", "Sanchez Romero", "46469815V", new DateTime(1988, 2, 28).ToLocalTime(), DateTime.Now, 30) };
            yield return new object[] { new Student(Guid.NewGuid(), 2, "Elisabet", "Bayot Bertran", "46960066T", new DateTime(1987, 07, 25).ToLocalTime(), DateTime.Now, 30) };
        }



        [DataTestMethod]
        [DynamicData(nameof(StudentData), DynamicDataSourceType.Method)]
        public void TxtSaveTest(Student alumno)
        {
            StudentRepository.ChangeFormat(Enums.DataTypeAccess.txt);
            var result = StudentRepository.Add(alumno);
            Assert.IsTrue(alumno.Equals(result));
        }

        [DataTestMethod]
        [DynamicData(nameof(StudentData), DynamicDataSourceType.Method)]
        public void JsonSaveTest(Student alumno)
        {
            StudentRepository.ChangeFormat(Enums.DataTypeAccess.json);
            var result = StudentRepository.Add(alumno);
            Assert.IsTrue(alumno.Equals(result));
        }

        [DataTestMethod]
        [DynamicData(nameof(StudentData), DynamicDataSourceType.Method)]
        public void XmlSaveTest(Student alumno)
        {
            StudentRepository.ChangeFormat(Enums.DataTypeAccess.xml);
            var result = StudentRepository.Add(alumno);
            Assert.IsTrue(alumno.Equals(result));
        }
    }
}
