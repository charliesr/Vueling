using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.Business.Logic.Tests
{
    [TestClass()]
    public class StudentBLTests
    {
        private readonly IStudentBL studentBL = new StudentBL();
        public static IEnumerable<object[]> FechasData()
        {
            yield return new object[] { new DateTime(2018, 4, 4), new DateTime(1988, 2, 28), 30 };
            yield return new object[] { new DateTime(2010, 4, 4), new DateTime(1988, 2, 28), 22 };
        }
        [DataTestMethod]
        [DynamicData(nameof(FechasData), DynamicDataSourceType.Method)]
        public void CalcularEdadTest(DateTime registro, DateTime nacimiento, int result)
        {
            Assert.IsTrue(studentBL.CalcularEdad(registro, nacimiento) == result);
        }
    }
}