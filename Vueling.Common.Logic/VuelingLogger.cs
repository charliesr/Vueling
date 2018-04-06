using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;

namespace Vueling.Common.Logic
{
    public class VuelingLogger : IVuelingLogger
    {
        static VuelingLogger()
        {
            Init();
        }

        public static void Init()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout();

            // Ingresamos la patter que seguirá el log
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            //Instancia del appender tipo rolling con sus opciones
            var roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = @"Logs\EventLog.txt";
            roller.Layout = patternLayout;
            roller.MaximumFileSize = "10MB";
            roller.MaxSizeRollBackups = 10;
            roller.RollingStyle = RollingFileAppender.RollingMode.Date;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
        }
        private readonly ILog log;
        public VuelingLogger(Type declaringType )
        {
            log = LogManager.GetLogger(declaringType);
        }

        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Fatal(object message)
        {
            log.Fatal(message);
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void Warn(object message)
        {
            log.Warn(message);
        }

        public void Error(Exception ex)
        {
            log.Error("Se ha producido una excepción de tipo " + ex.GetType().Name, ex);
        }
    }
}
