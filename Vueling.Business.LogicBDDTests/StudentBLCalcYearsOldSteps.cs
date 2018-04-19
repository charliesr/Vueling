using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using Vueling.Business.Logic;

namespace Vueling.Business.LogicBDDTests
{
    [Binding]
    public class StudentBLCalcYearsOldSteps
    {
        private readonly IStudentBL _studenBL = new StudentBL();
        private DateTime FechaRegistro;
        private DateTime FechaNacimiento;
        private int Resultado;
        [Given(@"I have entered ""(.*)"" into the Year calculator")]
        public void GivenIHaveEnteredIntoTheYearCalculator(string fechaRegistro)
        {
            FechaRegistro = DateTime.Parse(fechaRegistro);
        }
        
        [Given(@"I have also entered ""(.*)"" into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(string fechaNacimiento)
        {
            FechaNacimiento = DateTime.Parse(fechaNacimiento);
        }
        
        [When(@"I call CalcEdad")]
        public void WhenICallCalcEdad()
        {
            Resultado = _studenBL.CalcularEdad(FechaRegistro, FechaNacimiento);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int resultado)
        {
            Assert.AreEqual(Resultado, resultado);
        }
    }
}
