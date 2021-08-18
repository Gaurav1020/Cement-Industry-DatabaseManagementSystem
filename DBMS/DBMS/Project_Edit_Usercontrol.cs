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
    public partial class Project_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static Project_Edit_Usercontrol _instance;
        public static Project_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Project_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public Project_Edit_Usercontrol()
        {
            InitializeComponent();
        }

        //SEARCH
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("Project_Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iProject_ID", textBox1.Text);
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
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Exception Caught:\n" );
            }

            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("Project_Search_SP", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("iProject_ID", textBox1.Text);
                MySqlDataReader dr = cmd1.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        string pid = dr.GetString("Project_ID");
                        textBox8.Text = pid;
                        string pname = dr.GetString("Project_Name");
                        textBox7.Text = pname;
                        string ploc = dr.GetString("Project_Location");
                        textBox6.Text = ploc;
                        string sop = dr.GetString("Stage_Of_Project");
                        textBox5.Text = sop;
                        string pt = dr.GetString("Project_Type");
                        textBox4.Text = pt;
                        string u = dr.GetString("Unit");
                        textBox3.Text = u;
                        string ph = dr.GetString("Project_Head");
                        textBox2.Text = ph;

                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("inner");
                }

            }
            catch (Exception )
            {
                MessageBox.Show("" );
            }
            con.Close();

        }//SEARCH

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Project_Edit_Usercontrol_Load(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        //Data Grid Refresh
        public void Refresh_Data_Grid()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Project_Refresh_SP", con);
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
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Exception Caught:\n" );
            }
        } //Data Grid Refresh

        //ADD TUPLE
        private void button2_Click(object sender, EventArgs e)
        {

            MySqlParameter[] pms = new MySqlParameter[7];
            pms[0] = new MySqlParameter("iProject_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iProject_Name", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iProject_Location", MySqlDbType.VarChar);
            pms[2].Value = textBox6.Text;
            pms[3] = new MySqlParameter("iStage_Of_Project", MySqlDbType.VarChar);
            pms[3].Value = textBox5.Text;
            pms[4] = new MySqlParameter("iProject_Type", MySqlDbType.VarChar);
            pms[4].Value = textBox4.Text;
            pms[5] = new MySqlParameter("iUnit", MySqlDbType.VarChar);
            pms[5].Value = textBox3.Text;
            pms[6] = new MySqlParameter("iProject_Head", MySqlDbType.VarChar);
            pms[6].Value = textBox2.Text;

            MySqlCommand cmd = new MySqlCommand("Project_Add_SP", con);
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
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope.\n\n");
            }
            con.Close();
            Refresh_Data_Grid();

        } //ADD TUPLE

        private void button5_Click(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Project_Delete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iProject_ID", textBox8.Text);
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[6];
            pms[0] = new MySqlParameter("iProject_Name", MySqlDbType.VarChar);
            pms[0].Value = textBox7.Text;
            pms[1] = new MySqlParameter("iProject_Location", MySqlDbType.VarChar);
            pms[1].Value = textBox6.Text;
            pms[2] = new MySqlParameter("iStage_Of_Project", MySqlDbType.VarChar);
            pms[2].Value = textBox5.Text;
            pms[3] = new MySqlParameter("iProject_Type", MySqlDbType.VarChar);
            pms[3].Value = textBox4.Text;
            pms[4] = new MySqlParameter("iUnit", MySqlDbType.VarChar);
            pms[4].Value = textBox3.Text;
            pms[5] = new MySqlParameter("iProject_Head", MySqlDbType.VarChar);
            pms[5].Value = textBox2.Text;

            MySqlCommand cmd = new MySqlCommand("Project_Update_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iProject_ID", textBox8.Text);
            cmd.Parameters.AddRange(pms);
            con.Open();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Tuple Updated");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope. ");
            }
            con.Close();
            Refresh_Data_Grid();
        }
    }
}