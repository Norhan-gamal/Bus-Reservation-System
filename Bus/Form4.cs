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
    public partial class Form4 : Form
    {
        string d_access = "Data source=orcl;User id=scott;Password=tiger;";
        OracleConnection conn;
        CrystalReport5 cr;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr;
        }

        private void Form4_Load(object sender, EventArgs e)
        { 
            cr=new CrystalReport5();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
