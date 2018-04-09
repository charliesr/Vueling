using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic
{
    public static class FileUtils
    {
        public static string GetFilePath<T>(DataTypeAccess typeFile)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), typeof(T).Name + "." + typeFile.ToString());
        }
    }
}
