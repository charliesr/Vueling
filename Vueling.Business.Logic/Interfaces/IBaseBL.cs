using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic.Interfaces
{
    public interface IBaseBL<T> where T : IVuelingModelObject
    {
        T Add(T alumno);
        T GetByGUID(Guid guid);
        List<T> GetAll();
        int DeleteByGUID(Guid guid);
        T Update(int id, Student student);
        T GetById(int id);
        int DeleteById(int id);
        Student InitStudent();


    }
}
