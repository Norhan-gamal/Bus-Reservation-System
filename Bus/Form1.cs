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

namespace connectedform
{
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;"; 
        OracleConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select tripsID,price,tripDate from tripsTable where distination=:dist";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("dist", comboBox1.SelectedItem.ToString());
            OracleDataReader d = cmd.ExecuteReader();
            while (d.Read())
            {
                tripid.Items.Add(d[0].ToString());
                price.Items.Add(d[1].ToString());
                date.Items.Add(d[2].ToString());
            }
            d.Close();
        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into tripsTable values (:id,:pr,:avail,:dest,:dato)";
            cmd.Parameters.Add("id", comboBox2.Text);
            cmd.Parameters.Add("pr", textBox4.Text);
            cmd.Parameters.Add("avail", textBox5.Text);
            cmd.Parameters.Add("dest", textBox1.Text);
            cmd.Parameters.Add("dato", textBox3.Text);
            int r = cmd.ExecuteNonQuery();
            if(r!=-1)
            {
                comboBox2.Items.Add(comboBox2.Text);
                MessageBox.Show("new trip is added");
            }
        }

        private void trip_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("pr", OracleDbType.Double,ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                txt_1row_p.Text= cmd.Parameters["pr"].Value.ToString();
            }
            catch
            {
                txt_1row_p.Text = "null";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("dist", comboBox1.Text);
            cmd.Parameters.Add("id", OracleDbType.RefCursor,ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                tripid.Items.Add(dr[0]);
            }
            dr.Close();
        }
    }
}
