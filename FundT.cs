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
    public partial class FundT : Form
    {
        int bal,bal2;
        public FundT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Account WHERE accnumber ='" + txtAccNo1.Text + "'";
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
                            txtAccNo2.Visible = true;
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

        private void FundT_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            txtAccNo2.Hide();
            button2.Hide();
            label4.Hide();
            txtAmount.Hide();
            button3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Account WHERE accnumber ='" + txtAccNo2.Text + "'";
                using (SqlCommand cmd2 = new SqlCommand(cmd, con))
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            bal2 = reader.GetInt32(2);
                            label4.Visible = true;
                            txtAmount.Visible = true;
                            button3.Visible = true;
                        }
                        else
                        {
                            label4.Text = "Account Not Found";
                            label4.Visible = true;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                if (int.Parse(txtAmount.Text) < bal)
                {
                    String cmd = "UPDATE Account SET balance = balance - " + int.Parse(txtAmount.Text) + " WHERE accnumber = " + txtAccNo1.Text;
                    SqlCommand cmd2 = new SqlCommand(cmd, con);
                    cmd2.ExecuteNonQuery();
                    int newbal = bal - int.Parse(txtAmount.Text);
                    String cmd1 = "INSERT INTO Transact VALUES(" + int.Parse(txtAccNo1.Text) + ",'Debit'," + int.Parse(txtAmount.Text) + "," + newbal + ",'" + DateTime.Now.Date + "')";
                    SqlCommand cmd3 = new SqlCommand(cmd1, con);
                    cmd3.ExecuteNonQuery();
                    String cmd4 = "UPDATE Account SET balance = balance + " + int.Parse(txtAmount.Text) + " WHERE accnumber = " + txtAccNo2.Text;
                    SqlCommand cmd5 = new SqlCommand(cmd4, con);
                    cmd5.ExecuteNonQuery();
                    int newbal2 = bal2 + int.Parse(txtAmount.Text);
                    String cmd6 = "INSERT INTO Transact VALUES(" + int.Parse(txtAccNo2.Text) + ",'Credit'," + int.Parse(txtAmount.Text) + "," + newbal2 + ",'" + DateTime.Now.Date + "')";
                    SqlCommand cmd7 = new SqlCommand(cmd6, con);
                    cmd7.ExecuteNonQuery();
                    label4.Enabled = false;
                    txtAmount.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }
    }
}
