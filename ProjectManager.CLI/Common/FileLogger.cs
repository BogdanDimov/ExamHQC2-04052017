using log4net;

namespace ProjectManager.CLI.Common
{
    public class FileLogger
    {
        private static readonly ILog Log;

        static FileLogger()
        {
            Log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void LogInfoMessage(object message)
        {
            Log.Info(message);
        }

        public void LogErrorMessage(object message)
        {
            Log.Error(message);
        }

        public void LogFatalError(object message)
        {
            Log.Fatal(message);
        }
    }
}
