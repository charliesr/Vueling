using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using Vueling.Business.Logic;
using Vueling.Business.Logic.Interfaces;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Facade.WindowsComunicationFoundation
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StudentService : IStudentService
    {
        private readonly IStudentBL studentBL;

        public Student AddStudent(Student student)
        {
            return studentBL.Add(student);
        }

        public int DeleteStudentById(int id)
        {
            return studentBL.DeleteById(id);
        }

        public Student GetStudentById(int id)
        {
            return studentBL.GetById(id);
        }

        public Student UpdateStudent(Student student)
        {
            return studentBL.Update(student.ID, student);
        }
    }
}