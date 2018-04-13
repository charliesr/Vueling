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

            // Ingresamos la pattern que seguirá el log
            var rollingPatternLayout = new PatternLayout()
            {
                ConversionPattern = "%date [%thread] %-5level %logger - %message%newline"
            };
            var mailingPatternLayout = new PatternLayout()
            {
                ConversionPattern = "%level %date - %message%newline"
            };
            rollingPatternLayout.ActivateOptions();
            mailingPatternLayout.ActivateOptions();


            //Instancia del appender tipo rolling con sus opciones
            var roller = new RollingFileAppender
            {
                AppendToFile = true,
                File = @"Logs\EventLog.txt",
                Layout = rollingPatternLayout,
                MaximumFileSize = "10MB",
                MaxSizeRollBackups = 10,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = true
            };
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            //Instancia del appender tipo Mail con sus opciones
            //var mailer = new SmtpAppender()
            //{
            //    SmtpHost = "smtp.gmail.com",
            //    Port = 587,
            //    Authentication = SmtpAppender.SmtpAuthentication.Basic,
            //    Username = "charlvuel@gmail.com",
            //    Password = "",
            //    BufferSize = 1,
            //    From = "charlvuel@gmail.com",
            //    To = "carles.sanchez@atmira.com",
            //    EnableSsl = true,
            //    Subject = "Mail de logs de errores graves en Student 3 capas",
            //    Layout = mailingPatternLayout,
            //    Threshold = Level.Error
            //};
            //mailer.ActivateOptions();
            //hierarchy.Root.AddAppender(mailer);

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
#if DEBUG
            log.Debug(message);
#endif
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
