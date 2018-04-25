using System;

namespace Vueling.Common.Logic.Utils
{
    public interface IVuelingLogger
    {
        void Init(Type declaringType);
        void Debug(object message);
        void Fatal(object message);
        void Warn(object message);
        void Error(object message);
        void Info(object message);
        void Error(Exception ex);
    }
}