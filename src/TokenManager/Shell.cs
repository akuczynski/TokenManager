using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;

namespace TokenManager
{
    static class Shell
    {
        public static CompositionContainer CompositionContainer { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            Application.Run(mainForm);
        }

        private static void Init()
        {
            // MEF 
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Shell).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(INotificationService).Assembly));
            CompositionContainer = new CompositionContainer(catalog);
        }
    }
}
