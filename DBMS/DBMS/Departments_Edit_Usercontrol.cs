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
    public partial class Departments_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static Departments_Edit_Usercontrol _instance;
        public static Departments_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Departments_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public Departments_Edit_Usercontrol()
        {
            InitializeComponent();
        }

        public void Refresh_Data_Grid()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Departments_Refresh_SP", con);
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
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception)
            {
                MessageBox.Show("Exception Caught:\n" );
            }
        } //Data Grid Refresh

        private void Departments_Load(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[4];
            pms[0] = new MySqlParameter("iDept_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iDept_Name", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iDept_Head", MySqlDbType.VarChar);
            pms[2].Value = textBox5.Text;
            pms[3] = new MySqlParameter("iProject_ID", MySqlDbType.VarChar);
            pms[3].Value = textBox2.Text;


            MySqlCommand cmd = new MySqlCommand("Departments_Add_SP", con);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand("Departments_Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iDept_ID", textBox1.Text);
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
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception )
            {
                MessageBox.Show("Exception Caught:\n" );
            }

            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("Departments_Search_SP", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("iDept_ID", textBox1.Text);
                MySqlDataReader dr = cmd1.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        string did = dr.GetString("Department_ID");
                        textBox8.Text = did;
                        string dn = dr.GetString("Department_Name");
                        textBox7.Text = dn;
                        string dh = dr.GetString("Department_Head");
                        textBox5.Text = dh;
                        string pid = dr.GetString("Project_ID");
                        textBox2.Text = pid;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("inner");
                }

            }
            catch (Exception )
            {
                MessageBox.Show("" );
            }
            con.Close();
        }//SEARCH TUPLE

        private void button5_Click(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }//REFRESH TABLE

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[4];
            pms[0] = new MySqlParameter("iDept_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iDept_Name", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iDept_Head", MySqlDbType.VarChar);
            pms[2].Value = textBox5.Text;
            pms[3] = new MySqlParameter("iProject_ID", MySqlDbType.VarChar);
            pms[3].Value = textBox2.Text;

            MySqlCommand cmd = new MySqlCommand("Departments_Update_SP", con);
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
                MySqlCommand cmd = new MySqlCommand("Departments_Delete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iDept_ID", textBox8.Text);
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
            catch (Exception)
            {
                MessageBox.Show("Error Deleting the tuple.\nPlease verify the Tuple ID to be deleted. ");
            }
            Refresh_Data_Grid();
        }//DELETE TUPLE
    }
}
