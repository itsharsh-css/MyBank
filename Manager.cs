using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBank
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void approveAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approved a = new Approved();
            a.Show();
        }
    }
}
