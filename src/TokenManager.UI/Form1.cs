using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TokenManager.Core.Controllers;

namespace TokenManager
{
    public partial class Form1 : Form
    {
        [Import]
        public IMainViewController MainViewController { get; set; }

        public Form1()
        {
            InitializeComponent();

            Shell.CompositionContainer.ComposeParts(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Shell.Configuration["MainFolderPath"];
            MainViewController.ShowList();

         
        }
    }
}
