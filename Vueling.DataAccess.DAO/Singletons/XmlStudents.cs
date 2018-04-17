using System.Collections.Generic;
using System.Reflection;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.DAO.Singletons
{
    public class XmlStudents
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static XmlStudents _instance;
        private readonly List<Student> _students;
        private static object syncLock = new object();

        protected XmlStudents()
        {
            _log.Debug("Ojo! nueva instancia del singleton XML!!");
            var _format = FormatFactory<Student>.GetFormat(DataTypeAccess.xml);
            _students = _format.GetAll();
        }

        public static XmlStudents GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new XmlStudents();
                    }
                }
            }
            return _instance;
        }

        public List<Student> GetAll()
        {
            _log.Debug("Singleton de xml devuelve alumnos INTERNOS");
            return _students;
        }
    }
}
