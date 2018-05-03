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
            SetVariable(CommonLiterals.FactoryFormat, format);
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save();
        }

        public static DataTypeAccess LoadFormat()
        {
            return StringToDataTypeAccess(LoadVariable(CommonLiterals.FactoryFormat));
        }

        public static Type LoadTypeLogger()
        {
            return Assembly.GetExecutingAssembly().GetType(
                new StringBuilder(Assembly.GetExecutingAssembly().GetName().Name)
                .Append(CommonLiterals.Dot)
                .Append(CommonLiterals.Utils)
                .Append(CommonLiterals.Dot)
                .Append(LoadVariable(CommonLiterals.LogggerKey)).ToString());
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

        private static void SetVariable(string key, string value)
        {
            ConfigurationManager.AppSettings[key] = value;
        }

        public static string GetConnecionString()
        {
            return LoadVariable(CommonLiterals.ConnectionKey);
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
            return LoadVariable(CommonLiterals.BaseAddKey);
        }

        public static string GetRedisEndpoint()
        {
            return LoadVariable(CommonLiterals.RedisKey);
        }

        public static string GetConfigForWebClient()
        {
            return LoadVariable(CommonLiterals.MimeHeaderKey);
        }

    }
}
