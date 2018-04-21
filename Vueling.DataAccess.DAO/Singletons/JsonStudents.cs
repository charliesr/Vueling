using System.Collections.Generic;
using System.Reflection;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.FormatImplementations;

namespace Vueling.DataAccess.DAO
{
    public class JsonStudents
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static JsonStudents _instance;
        private readonly List<Student> _students;
        private static object syncLock = new object();

        protected JsonStudents()
        {
            _log.Debug("Ojo! nueva instancia del singleton JSON!!");
            var _format = FormatFactory<Student>.GetFormat(DataTypeAccess.json);
            _students = _format.GetAll();
        }

        public static JsonStudents GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new JsonStudents();
                    }
                }
            }
            return _instance;
        }

        public List<Student> GetAll()
        {
            _log.Debug("Singleton de json devuelve alumnos INTERNOS");
            return _students;
        }
    }
}
