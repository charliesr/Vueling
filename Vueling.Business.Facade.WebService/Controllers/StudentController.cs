﻿using System;
using System.Reflection;
using System.Web.Http;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using System.Text;
using System.Web;
using Vueling.Business.Logic;
using Vueling.Business.Logic.Interfaces;
using Vueling.Business.Facade.WebService.App_Start;

namespace Vueling.Business.Facade.WebService.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IVuelingLogger log;
        private readonly IStudentBL _studentBl;

        public StudentController(IStudentBL studentBL, IVuelingLogger log)
        {
            this._studentBl = studentBL;
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Return a student by guid
        /// </summary>
        /// <param name="guid"> Guid from a student to search</param>
        /// <returns>A Student</returns>
        [HttpGet()]
        public IHttpActionResult GetStudentByGuid(Guid guid)
        {
            try
            {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.GetByGUID(guid));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Return a student by id
        /// </summary>
        /// <param name="id"> id from a student to search</param>
        /// <returns>A Student</returns>
        [CustomExceptionFilter]
        [HttpGet()]
        public IHttpActionResult ReadStudent(int id)
        {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.GetById(id));
        }

        /// <summary>
        /// Return all students
        /// </summary>
        /// <returns>List of all students</returns>
        [HttpGet()]
        public IHttpActionResult GetAllStudents()
        {
            try
            {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.GetAll());
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Add a student
        /// </summary>
        /// <param name="student"> Student to Add</param>
        /// <returns>A Student</returns>
        [HttpPost()]
        public IHttpActionResult AddStudent(Student student)
        {
            try
            {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.Add(student));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete a student by guid
        /// </summary>
        /// <param name="guid"> guid from a student to delete</param>
        /// <returns>A Student</returns>
        [HttpDelete()]
        public IHttpActionResult DeleteStudentByGuid(Guid guid)
        {
            try
            {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.DeleteByGUID(guid));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError();
            }

        }

        /// <summary>
        /// Delete a student by id
        /// </summary>
        /// <param name="id"> id from a student to delete</param>
        /// <returns>A Student</returns>
        [HttpDelete()]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.DeleteById(id));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError();
            }

        }

        /// <summary>
        /// Update a student
        /// </summary>
        /// <param name="id"> id whose student we want to update</param>
        /// <param name="student"> Student to Update</param>
        /// <returns>A Student</returns>
        [HttpPut()]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                log.Debug(new StringBuilder(LogLiterals.RequestReceived).Append(HttpContext.Current.Request.HttpMethod).Append(" ").Append(MethodBase.GetCurrentMethod().Name).ToString());
                return Ok(_studentBl.Update(id,student));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// ping api
        /// </summary>
        /// <returns>string with result</returns>
        [HttpGet()]
        public IHttpActionResult Trial()
        {
            return Ok("Estamos en el método trial");
        }
    }
}
