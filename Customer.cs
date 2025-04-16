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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                string gender;
                if (cmbGender.Text == "Male")
                    gender = "M";
                else
                    gender = "F";
                string cmd = "INSERT INTO Customer VALUES('" + txtName.Text + "','" + txtAddress.Text + "'," + int.Parse(txtAge.Text) + ",'" + gender + "','no' )";
                SqlCommand cmd2 = new SqlCommand(cmd, con);
                cmd2.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
