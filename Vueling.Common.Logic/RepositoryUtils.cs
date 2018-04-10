using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic
{
    public static class RepositoryUtils
    {
        public static string GetFilePath<T>(DataTypeAccess typeFile)
        {
            return typeFile.ToString().Contains("DB") ? ConfigurationManager.AppSettings["ConnectionString"] : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), typeof(T).Name + "." + typeFile.ToString());
        }
    }
}
