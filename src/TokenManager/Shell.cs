using System;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
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

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            var mainForm = new MainForm();
            Application.Run(mainForm);
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            
            //throw new NotImplementedException();
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhandled Thread Exception");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception).Message, "Unhandled UI Exception");
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
