using NLog;
using NLog.Config;
using NLog.Targets;

namespace TokenManager.UI
{
    internal static class Log
    {
        public static Logger Instance { get; private set; }
        static Log()
        {
#if DEBUG

            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            fileTarget.FileName = "${basedir}\\TokenManager.log";
            fileTarget.Layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss}: ${message}";

            var rule = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
#endif
            Instance = LogManager.GetCurrentClassLogger();
        }
    }
}
