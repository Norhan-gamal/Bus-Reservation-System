using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connectedform;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace Bus
{
    public partial class MainForm : Form
    {
        string d_access = "Data source=orcl;User id=scott;Password=tiger;";
        OracleConnection conn;
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn=new OracleConnection(d_access);
            conn.Open();
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
           
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           Form3 r = new Form3();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 r = new Form4();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
