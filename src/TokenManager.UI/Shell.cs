using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TokenManager.Core.Controllers;
using TokenManager.UI;

namespace TokenManager
{
    static class Shell
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static CompositionContainer CompositionContainer { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Init();
            Application.Run(new Form1());
        }

        private static void Init()
        {
            // Config
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            Configuration = builder.Build();

            // MEF 
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Shell).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IMainViewController).Assembly));
            CompositionContainer = new CompositionContainer(catalog);

            // Nlog 
            Log.Instance.Info("Application Initialization.");
        }
    }
}
