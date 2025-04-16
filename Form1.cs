using System.Data.SqlClient;

namespace MyBank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Nilesh Natekar\\Documents\\BankDB.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con=new SqlConnection(str))
            {
                con.Open();
                String cmd = "SELECT * FROM Login WHERE username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'";
                using (SqlCommand cmd2 = new SqlCommand(cmd, con))
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            if (reader.GetString(2)=="cashier")
                            {
                                Cashier c = new Cashier();
                                c.Show();
                              //  this.Hide();
                            }
                            else if (reader.GetString(2) == "clerk")
                            {
                                Clerk cl = new Clerk();
                                cl.Show();
                           //   this.Hide();
                            }
                            else
                            {
                                Manager m = new Manager();
                                m.Show();
                             //   this.Hide();
                            }
                        }
                    }
                }
            }
        }
    }
}
