using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Shahid;


namespace WindowsFormsApp1
{
    public partial class Login_As_User_Form : Form
    {
        string ordb = "Data Source=ORCL; User Id=Shahid; Password=123;";
        OracleConnection conn;
        public Login_As_User_Form()
        {
            InitializeComponent();
        }

        private void Login_As_User_Form_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM USERS WHERE user_name=:username AND useremail=:email AND userpass=:password";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(":adminname", OracleDbType.Varchar2).Value = username;
            cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
            cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                // If the username and password are correct, display a message and close the login form
                MessageBox.Show("Login successful!");
                Main_Form user_main_form = new Main_Form();
                user_main_form.Show();
                this.Close();
            }
            else
            {
                // If the username and password are incorrect, display an error message
                MessageBox.Show("Invalid  name or email or password. Please try again.");
            }
        }
    }
}
