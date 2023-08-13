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


namespace Bus
{
    public partial class Form3 : Form
    {
        string d_access = "Data source=orcl;User id=scott;Password=tiger;";
        OracleConnection conn;
        CrystalReport3 cr;
        public Form3()
        {
            InitializeComponent();
        }
       
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            cr = new CrystalReport3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
