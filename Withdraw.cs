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
    public partial class Withdraw : Form
    {
        int bal;
        public Withdraw()
        {
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            txtAmount.Hide();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Account WHERE accnumber ='" + txtAccNo.Text + "'";
                using (SqlCommand cmd2 = new SqlCommand(cmd, con))
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            bal = reader.GetInt32(2);
                            label2.Text = "Current Balance: " + bal.ToString();
                            label2.Visible = true;
                            txtAmount.Visible = true;
                            button2.Visible = true;
                            label3.Visible = true;
                        }
                        else
                        {
                            label2.Text = "Account Not Found";
                            label2.Visible = true;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                if (int.Parse(txtAmount.Text) < bal)
                {
                    String cmd = "UPDATE Account SET balance = balance - " + int.Parse(txtAmount.Text) + " WHERE accnumber = " + txtAccNo.Text;
                    SqlCommand cmd2 = new SqlCommand(cmd, con);
                    cmd2.ExecuteNonQuery();
                    int newbal = bal - int.Parse(txtAmount.Text);
                    String cmd1 = "INSERT INTO Transact VALUES(" + int.Parse(txtAccNo.Text) + ",'Withdraw'," + int.Parse(txtAmount.Text) + "," + newbal + ",'" + DateTime.Now.Date + "')";
                    SqlCommand cmd3 = new SqlCommand(cmd1, con);
                    cmd3.ExecuteNonQuery();
                    label3.Enabled = false;
                    txtAmount.Enabled = false;
                    button2.Enabled = false;
                }
            }
        }
    }
}
