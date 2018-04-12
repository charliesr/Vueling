using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic
{
    public static class ConfigurationUtils
    {
        public static void SaveFormat(string format)
        {
            ConfigurationManager.AppSettings["ConfiguredAccessType"] = format;
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save();
        }

        public static string LoadFormat()
        {
            return ConfigurationManager.AppSettings["ConfiguredAccessType"];
        }
    }
}
