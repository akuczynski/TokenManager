using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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
            string myPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            catalog.Catalogs.Add(new DirectoryCatalog(myPath));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Shell).Assembly));
            CompositionContainer = new CompositionContainer(catalog);
        }
    }
}
