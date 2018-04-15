using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Utils;

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

        public static IVuelingLogger LoadLogger(Type declaringType)
        {
            var type = Assembly.GetExecutingAssembly().GetType(new StringBuilder(Assembly.GetExecutingAssembly().GetName().Name).Append(".Utils").Append(".").Append(LoadVariable("LoggerFramework")).ToString());
            return (IVuelingLogger)Activator.CreateInstance(type,new object[] { declaringType });
        }

        private static string LoadVariable(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

    }
}
