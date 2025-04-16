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
    public partial class Approved : Form
    {
        public Approved()
        {
            InitializeComponent();
        }

        private void Approved_Load(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Customer WHERE approved ='no'";
                using (SqlCommand cmd2 = new SqlCommand(cmd, con))
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCustomer.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "UPDATE Customer SET approved ='yes' WHERE name = '" + cmbCustomer.Text + "'";
                SqlCommand cmd2 = new SqlCommand(cmd, con);
                cmd2.ExecuteNonQuery();
                String cmd1 = "INSERT INTO Account VALUES('" + cmbCustomer.Text + "',0)";
                SqlCommand cmd3 = new SqlCommand(cmd1, con);
                cmd3.ExecuteNonQuery();
            }
        }
    }
}
