using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using TokenManager.Core.Controllers;

namespace TokenManager
{
    static class Shell
    {
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
            Application.Run(new MainForm());
        }

        private static void Init()
        {
            // MEF 
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Shell).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IPersistanceController).Assembly));
            CompositionContainer = new CompositionContainer(catalog);
        }
    }
}
