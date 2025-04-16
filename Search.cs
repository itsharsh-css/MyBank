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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Customer WHERE name ='" + txtName.Text + "'";
                using (SqlCommand cmd2 = new SqlCommand(cmd, con))
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label2.Text = "Name: " + reader.GetString(0);
                            label3.Text = "Address: " + reader.GetString(1);
                            label4.Text = "Age: " + reader.GetInt32(2).ToString();
                            label5.Text = "Gender: " + reader.GetString(3);
                        }
                    }
                }
                String cmd3 = "SELECT * FROM Account WHERE custname ='" + txtName.Text + "'";
                using (SqlCommand cmd4 = new SqlCommand(cmd3, con))
                {
                    using (SqlDataReader reader = cmd4.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label6.Text = "Account Number: " + reader.GetInt32(0).ToString();
                            label7.Text = "Balance: " + reader.GetInt32(2).ToString();
                        }
                    }
                }
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
        }
    }
}
