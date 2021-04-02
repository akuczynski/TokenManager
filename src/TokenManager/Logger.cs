using System.ComponentModel.Composition;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace TokenManager
{

    [Export(typeof(Core.DomainServices.ILogger))]
    public class Logger  : Core.DomainServices.ILogger
    {
        public void Info(string text)
        {
            Log.Instance.Info(text);
        }
    }

    internal static class Log
    {
        public static NLog.Logger Instance { get; private set; }
        static Log()
        {
#if DEBUG

            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            fileTarget.FileName = "${basedir}\\" + Constants.LogFileName;
            fileTarget.Layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss}: ${message}";

            var rule = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
#endif
            Instance = LogManager.GetCurrentClassLogger();
        }
    }
}
