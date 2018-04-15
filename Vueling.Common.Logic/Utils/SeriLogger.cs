using System;
using System.Text;
using Serilog;

namespace Vueling.Common.Logic.Utils
{
    public class SeriLogger : IVuelingLogger
    {
        static SeriLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Async(sink => sink.RollingFile(@"Logs\StudentsLog-SeriLog.txt"))
                .WriteTo.Async(sink => sink.Console())
                .CreateLogger();
        }
        public SeriLogger(Type declaringType)
        {
            this.Debug(new StringBuilder(LogLiterals.enteringClass).Append(declaringType.FullName).ToString());
        }


        public void Debug(object message)
        {
#if DEBUG
            Log.Debug((string)message);
            Log.CloseAndFlush();
#endif
        }

        public void Error(object message)
        {
            Log.Error((string)message);
            Log.CloseAndFlush();
        }

        public void Error(Exception ex)
        {
            Log.Error(new StringBuilder(LogLiterals.exceptionThrown).Append(ex.GetType().Name).ToString());
            Log.CloseAndFlush();
        }

        public void Fatal(object message)
        {
            Log.Fatal((string)message);
            Log.CloseAndFlush();
        }

        public void Info(object message)
        {
            Log.Information((string)message);
            Log.CloseAndFlush();
        }

        public void Warn(object message)
        {
            Log.Warning((string)message);
            Log.CloseAndFlush();
        }
    }
}
