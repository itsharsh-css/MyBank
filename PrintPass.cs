using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBank
{
    public partial class PrintPass : Form
    {
        public PrintPass()
        {
            InitializeComponent();
        }

        private void PrintPass_Load(object sender, EventArgs e)
        {
            label2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Transact WHERE accnumber ='" + txtAccNo.Text + "' order by Id";
               
                            DataSet ds = new DataSet();
                           

                            SqlDataAdapter adap = new SqlDataAdapter(cmd, con);
                            adap.Fill(ds, "Transact");
                            dataGridView1.AutoGenerateColumns = true;
                            dataGridView1.DataSource = ds.Tables["Transact"];
            }
            
        }
    }
}
