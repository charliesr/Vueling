using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
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

        public static DataTypeAccess LoadFormat()
        {
            return StringToDataTypeAccess(ConfigurationManager.AppSettings["ConfiguredAccessType"]);
        }

        public static Type LoadTypeLogger()
        {
            return Assembly.GetExecutingAssembly().GetType(new StringBuilder(Assembly.GetExecutingAssembly().GetName().Name).Append(".Utils").Append(".").Append(LoadVariable("LoggerFramework")).ToString());
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

        public static string GetConnecionString()
        {
            return LoadVariable("ConnectionString");
        }

        public static string GetFilePath<T>(DataTypeAccess dataTypeAccess)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), typeof(T).Name + "." + dataTypeAccess.ToString());
        }

        public static DataTypeAccess StringToDataTypeAccess(string from)
        {
            return (DataTypeAccess)Enum.Parse(typeof(DataTypeAccess), from);
        }

        public static string GetWebClientAddress()
        {
            return LoadVariable("BaseAddress");
        }

        public static string GetRedisEndpoint()
        {
            return LoadVariable("RedisEndpoint");
        }

    }
}
