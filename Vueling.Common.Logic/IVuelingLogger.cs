namespace Vueling.Common.Logic
{
    public interface IVuelingLogger
    {
        void Debug(object message);
        void Fatal(object message);
        void Warn(object message);
        void Error(object message);
        void Info(object message);
    }
}