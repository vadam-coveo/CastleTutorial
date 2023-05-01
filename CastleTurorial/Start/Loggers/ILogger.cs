namespace Start.Loggers;

public interface ILogger
{
    void LogLessRelevantStuff(string message);
    void LogLogic(string message);
    void LogLifecycleEvent(string message);
    void Error(string message, Exception? exception = null);
}