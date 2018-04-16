using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using Vueling.Business.Logic;

namespace Vueling.Business.LogicBDDTests
{
    [Binding]
    public class StudentBLCalcYearsOldSteps
    {

        private DateTime _fechaNacimiento;
        private DateTime _fechaRegistro;
        private int _edad;
        private IStudentBL _studentBL = new StudentBL();

        [Given(@"I have entered ""(.*)"" into the Year calculator")]
        public void GivenIHaveEnteredIntoTheYearCalculator(string fechaRegistro)
        {
            _fechaRegistro = DateTime.Parse(fechaRegistro);
        }
        
        [Given(@"I have also entered ""(.*)"" into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(string fechaNacimiento)
        {
            _fechaNacimiento = DateTime.Parse(fechaNacimiento);
        }

        [When(@"I call CalcEdad")]
        public void WhenICallCalcEdad()
        {
            _edad = _studentBL.CalcularEdad(_fechaRegistro, _fechaNacimiento);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int result)
        {
            Assert.AreEqual(_edad, result);
        }
    }
}
