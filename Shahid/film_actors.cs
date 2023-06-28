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
    public partial class film_actors : Form
    {
        public film_actors()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void film_actors_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=ORCL; User Id=ffff; Password=123";

            string cmdstr = "select FILM_NAME, FILM_DESCRIPTION ,RELEASE_DATE from FILMS  , FILM_ACTOR , ACTORS where FILMS.FILM_ID = FILM_ACTOR.FILM_ID and ACTORS.ACTOR_ID = FILM_ACTOR.ACTOR_ID and ACTORS.ACTOR_NAME = :n ";
            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("n", textBox1.Text);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
