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
    public partial class MGP_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static MGP_Edit_Usercontrol _instance;
        public static MGP_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MGP_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public MGP_Edit_Usercontrol()
        {
            InitializeComponent();
        }
        public void Refresh_Data_Grid()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("MGP_Refresh_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
            catch (Exception )
            {
                MessageBox.Show("Exception Caught:\n" );
            }
        } //Data Grid Refresh
        private void MGP_Edit_Usercontrol_Load(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("iMY", MySqlDbType.Date);
            pms[0].Value = dateTimePicker1.Value.Date;
            pms[1] = new MySqlParameter("iP_ID", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iTP", MySqlDbType.Float);
            pms[2].Value = textBox2.Text;
            pms[3] = new MySqlParameter("iUP", MySqlDbType.VarChar);
            pms[3].Value = textBox5.Text;
            pms[4] = new MySqlParameter("iPR", MySqlDbType.Float);
            pms[4].Value = textBox4.Text;



            MySqlCommand cmd = new MySqlCommand("MGP_Add_SP", con);
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
        }//ADD TUPLE

        private void button5_Click(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }//REFRESH TABLE

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("MGP_Delete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iMY", dateTimePicker1.Value.Date);
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("MGP_Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iMY", dateTimePicker2.Value.Date);
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

            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("MGP_Search_SP", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("iMY", dateTimePicker2.Value.Date);
                MySqlDataReader dr = cmd1.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        string eid = dr.GetDateTime("Month_and_Year").ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(eid);
                        string ename = dr.GetString("Project_ID");
                        textBox7.Text = ename;
                        string dob = dr.GetFloat("Total_Production").ToString();
                        textBox2.Text = dob;
                        string des = dr.GetString("Unit_of_Production");
                        textBox5.Text = des;
                        string adr = dr.GetFloat("Profit_Rate").ToString();
                        textBox4.Text = adr;

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
        }//SEARCH TUPLE

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("iMY", MySqlDbType.Date);
            pms[0].Value = dateTimePicker1.Value.Date;
            pms[1] = new MySqlParameter("iP_ID", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iTP", MySqlDbType.Float);
            pms[2].Value = textBox2.Text;
            pms[3] = new MySqlParameter("iUP", MySqlDbType.VarChar);
            pms[3].Value = textBox5.Text;
            pms[4] = new MySqlParameter("iPR", MySqlDbType.Float);
            pms[4].Value = textBox4.Text;

            MySqlCommand cmd = new MySqlCommand("MGP_Update_SP", con);
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
    }
}
