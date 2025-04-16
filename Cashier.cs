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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }

        private void accountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit d = new Deposit();
            d.Show();
        }

        private void withdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw w = new Withdraw();
            w.Show();
        }

        private void fundTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FundT f = new FundT();
            f.Show();
        }
    }
}
