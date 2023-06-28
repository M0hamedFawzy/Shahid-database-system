using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Shahid
{
    public partial class Form_admin_report : Form
    {
        CrystalReport_admin CR;
        public Form_admin_report()
        {
            InitializeComponent();
        }

        private void Form_admin_report_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport_admin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }
    }
}
