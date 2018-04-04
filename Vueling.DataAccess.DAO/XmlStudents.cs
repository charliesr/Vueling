using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public class XmlStudents
    {
        private static XmlStudents _instance;
        private readonly List<Student> _students;
        private static object syncLock = new object();

        protected XmlStudents()
        {
            var _format = FormatFactory<Student>.GetFormat(DataTypeAccess.json);
            _students = _format.SelectAll();
        }

        public static XmlStudents GetXmlStudents()
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
            return _students;
        }
    }
}
