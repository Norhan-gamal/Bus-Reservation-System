using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus
{
    public partial class Form2 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Selected == true)
                    {
                        name = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        name = name.ToLower();
                    }
                }
            }
            if (radioButton2.Checked)
            {
                if (name != "cancelled" || name == "")
                {
                    MessageBox.Show("Changed trips can be cancelled only");
                }
                else if (name == "cancelled")
                {

                    builder = new OracleCommandBuilder(adapter);
                    adapter.Update(ds.Tables[0]);
                    MessageBox.Show("Updated Sucessfully");
                }
            }
            else if (radioButton3.Checked)
            {
                if (name != "booked" || name == "")
                {
                    MessageBox.Show("Cancelled trips can be Booked only");
                }
                else if (name == "booked")
                {
                    builder = new OracleCommandBuilder(adapter);
                    adapter.Update(ds.Tables[0]);
                    MessageBox.Show("Updated Sucessfully");
                }
            }
            else if (radioButton1.Checked)
            {
                if (name == "")
                {
                    MessageBox.Show("Booked trips can be changed or cancelled only");
                }
                else if (name == "changed" || name == "cancelled")
                {
                    builder = new OracleCommandBuilder(adapter);
                    adapter.Update(ds.Tables[0]);
                    MessageBox.Show("Updated Sucessfully");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl ; User Id=scott; Password=tiger;";
            string cmdstr = "";
            if (radioButton1.Checked)
            {
                cmdstr = "select tripNo,custID,driverID,tripDestination,tripDate,seatNo,Status  " +
                    "from ticketTable  where  Status='Booked' or Status='booked' ";
            }
            else if (radioButton2.Checked)
            {
                cmdstr = "select tripNo,custID,driverID,tripDestination,tripDate,seatNo,Status  " +
                     "from ticketTable  where  Status='Changed' or Status='changed'";
            }
            else if (radioButton3.Checked)
            {
                cmdstr = "select tripNo,custID,driverID,tripDestination,tripDate,seatNo,Status  " +
                     "from ticketTable  where  Status='Cancelled' or Status='cancelled' ";
            }



            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
