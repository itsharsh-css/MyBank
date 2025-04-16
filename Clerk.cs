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
    public partial class Clerk : Form
    {
        public Clerk()
        {
            InitializeComponent();
        }

        private void accountCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Show();
        }

        private void customerSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }

        private void printPassbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPass p = new PrintPass();
            p.Show();
        }
    }
}
