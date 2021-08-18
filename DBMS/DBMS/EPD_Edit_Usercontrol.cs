using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace DBMS
{
    public partial class EPD_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static EPD_Edit_Usercontrol _instance;
        public static EPD_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EPD_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public EPD_Edit_Usercontrol()
        {
            InitializeComponent();
        }


        public void Refresh_Data_Grid()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("EPD_Refresh_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Refreshing the Database.\nException Caught:\n" );
                }
                con.Close();
                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Exception Caught:\n" );
            }
        } //Data Grid Refresh


        private void EPD_Edit_Usercontrol_Load(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        //ADD
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[6];
            pms[0] = new MySqlParameter("iEmp_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iEmp_Name", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iDate_Of_Birth", MySqlDbType.Date);
            pms[2].Value = dateTimePicker1.Value.Date;
            pms[3] = new MySqlParameter("iDesignation", MySqlDbType.VarChar);
            pms[3].Value = textBox5.Text;
            pms[4] = new MySqlParameter("iAddress", MySqlDbType.VarChar);
            pms[4].Value = textBox4.Text;
            pms[5] = new MySqlParameter("iDate_Of_Joining", MySqlDbType.Date);
            pms[5].Value = dateTimePicker2.Value.Date;


            MySqlCommand cmd = new MySqlCommand("EPD_Add_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddRange(pms);
            con.Open();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Tuple Added");

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope.\n\n" );
            }
            con.Close();
            Refresh_Data_Grid();
        }//ADD

        //SEARCH
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("EPD_Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iEmp_ID", textBox1.Text);
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception )
                {
                    MessageBox.Show("Error Refreshing the Database.\nException Caught:\n" );
                }

                con.Close();
                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Exception Caught:\n" );
            }

            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("EPD_Search_SP", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("iEmp_ID", textBox1.Text);
                MySqlDataReader dr = cmd1.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        string eid = dr.GetString("Emp_ID");
                        textBox8.Text = eid;
                        string ename = dr.GetString("Emp_Name");
                        textBox7.Text = ename;
                        string dob = dr.GetDateTime("Date_Of_Birth").ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(dob);
                        string des = dr.GetString("Designation");
                        textBox5.Text = des;
                        string adr = dr.GetString("Address");
                        textBox4.Text = adr;
                        string doj = dr.GetDateTime("Date_Of_Joining").ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(doj);

                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("Error Searching the ID. Try again after checking the ID.");
                }

            }
            catch (Exception )
            {
                MessageBox.Show("" );
            }
            con.Close();

        }//SEARCH

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[6];
            pms[0] = new MySqlParameter("iEmp_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iEmp_Name", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iDate_Of_Birth", MySqlDbType.Date);
            pms[2].Value = dateTimePicker1.Value.Date;
            pms[3] = new MySqlParameter("iDesignation", MySqlDbType.VarChar);
            pms[3].Value = textBox5.Text;
            pms[4] = new MySqlParameter("iAddress", MySqlDbType.VarChar);
            pms[4].Value = textBox4.Text;
            pms[5] = new MySqlParameter("iDate_Of_Joining", MySqlDbType.Date);
            pms[5].Value = dateTimePicker2.Value.Date;

            MySqlCommand cmd = new MySqlCommand("EPD_Update_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddRange(pms);
            con.Open();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Tuple Updated");

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope. ");
            }
            con.Close();
            Refresh_Data_Grid();
        }//UPDATE TUPLE

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("EPD_Delete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iEmp_ID", textBox8.Text);
                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Tuple Deleted");

                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("Error Deleting the tuple.\nPlease verify the Tuple ID to be deleted.");
                }
                con.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Error Deleting the tuple.\nPlease verify the Tuple ID to be deleted. ");
            }
            Refresh_Data_Grid();
        }//DELETE TUPLE
    }
}
