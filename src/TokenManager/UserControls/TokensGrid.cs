using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TokenManager.Core.ViewModel;

namespace TokenManager.UserControls
{
    public partial class TokensGrid : UserControl
    {
        public IEnumerable<TokenViewModel> MainGridDataSource
        {
            set
            {
                this.MainGrid.DataSource = value;
            }
        }

        public TokensGrid()
        {
            InitializeComponent();
        }

    }
}
