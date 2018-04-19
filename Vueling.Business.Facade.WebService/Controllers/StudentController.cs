using System;
using System.Reflection;
using System.Web.Http;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using System.Text;
using System.Web;
using Vueling.Business.Logic;

namespace Vueling.Business.Facade.WebService.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IVuelingLogger _log;
        private readonly IStudentBL _studentBL;


        public StudentController()
        {
            _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _studentBL = new StudentBL();
        }

        [HttpGet()]
        public IHttpActionResult GetStudentByGuid(Guid guid)
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                var student = _studentBL.GetByGUID(guid);
                return Ok(student);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        [HttpGet()]
        public IHttpActionResult ReadStudent(int id)
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                var student = _studentBL.GetById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        [HttpGet()]
        public IHttpActionResult GetAllStudents()
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                var students = _studentBL.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [HttpPut()]
        public IHttpActionResult AddStudent(Student student)
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBL.Add(student));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [HttpDelete()]
        public IHttpActionResult DeleteStudentByGuid(Guid guid)
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBL.DeleteByGUID(guid));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }

        }

        [HttpDelete()]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBL.DeleteById(id));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }

        }

        [HttpPost()]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                _log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBL.Update(id, student));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [HttpGet()]
        public IHttpActionResult Trial()
        {
            return Ok("Estamos en el método trial");
        }
    }
}
