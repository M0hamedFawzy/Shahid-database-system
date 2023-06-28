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
    public partial class Login_As_Admin_Form : Form
    {
        string ordb = "Data Source=ORCL; User Id=Shahid; Password=123;";
        OracleConnection conn;
        public Login_As_Admin_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the username and password entered by the user
            string adminname = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM ADMINS WHERE adminname=:adminname AND adminemail=:email AND adminpass=:password";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(":adminname", OracleDbType.Varchar2).Value = adminname;
            cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
            cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                // If the username and password are correct, display a message and close the login form
                MessageBox.Show("Login successful!");
                //Main_Form admin_main_form = new Main_Form();
                //admin_main_form.Show();
                this.Close();
            }
            else
            {
                // If the username and password are incorrect, display an error message
                MessageBox.Show("Invalid  name or email or password. Please try again.");
            }
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_As_Admin_Form_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
    }
}
