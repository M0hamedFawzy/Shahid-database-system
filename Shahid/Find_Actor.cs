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

namespace WindowsFormsApp1
{
    public partial class Find_Actor : Form
    {
        string ordb = "Data Source=ORCL; User Id=ffff; Password=123;";
        OracleConnection conn;
        public Find_Actor()
        {
            InitializeComponent();
        }

        private void Find_Actor_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select PLAN_ID from PAYMENT_PLAN";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "COMBO_ID";
            cm.Parameters.Add("payment_id", comboBox1.SelectedItem.ToString());
            cm.Parameters.Add("price", OracleDbType.Int32, ParameterDirection.Output);
            cm.Parameters.Add("due_tim", OracleDbType.Int32, ParameterDirection.Output);
            cm.ExecuteNonQuery();
            textBox1.Text = cm.Parameters[1].Value.ToString();
            textBox2.Text = cm.Parameters[2].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "show_all_plans";
            c.Parameters.Add("btn", OracleDbType.RefCursor, ParameterDirection.Output);
            using (OracleDataReader dr = c.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
