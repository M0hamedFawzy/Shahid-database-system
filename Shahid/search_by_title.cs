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
    public partial class search_by_title : Form
    {
        string ordb = "Data Source=ORCL; User Id=ffff; Password=123;";
        OracleConnection conn;
        public search_by_title()
        {
            InitializeComponent();
        }

        private void search_by_title_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT FILMS.FILM_DESCRIPTION , CATEGORY_LIST.CAREGORY_NAME FROM FILMS JOIN CATEGORY_LIST ON FILMS.FILMCATEGORYID = CATEGORY_LIST.CATEGORY_ID WHERE FILMS.FILM_NAME =:movie";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("movie", textBox1.Text);


            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }
            dr.Close();

            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "ACTOR_NAME";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("movie", textBox1.Text);
            cm.Parameters.Add("movie", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                listBox1.Items.Add(re[0]);
            }
            re.Close();
    }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
