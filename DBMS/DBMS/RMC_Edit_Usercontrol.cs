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
    public partial class RMC_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static RMC_Edit_Usercontrol _instance;
        public static RMC_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RMC_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public RMC_Edit_Usercontrol()
        {
            InitializeComponent();
        }

        public void Refresh_Data_Grid()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("RMC_Refresh_SP", con);
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
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            }
            catch (Exception )
            {
                MessageBox.Show("Exception Caught:\n" );
            }
        } //Data Grid Refresh
        private void RMC_Edit_Controlpanel_Load(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[3];
            pms[0] = new MySqlParameter("iRM_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iUnit", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iCost", MySqlDbType.Float);
            pms[2].Value = textBox5.Text;


            MySqlCommand cmd = new MySqlCommand("RMC_Add_SP", con);
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
                MySqlCommand cmd = new MySqlCommand("RMC_Delete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iRM_ID", textBox8.Text);
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
                MySqlCommand cmd = new MySqlCommand("RMC_Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iRM_ID", textBox1.Text);
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
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception )
            {
                MessageBox.Show("Exception Caught:\n" );
            }

            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("RMC_Search_SP", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("iRM_ID", textBox1.Text);
                MySqlDataReader dr = cmd1.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        string eid = dr.GetString("Raw_Material_ID");
                        textBox8.Text = eid;
                        string um = dr.GetString("Unit_of_Measurement");
                        textBox7.Text = um;
                        string cu = dr.GetFloat("Cost_per_Unit").ToString();
                        textBox5.Text = cu;

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
            MySqlParameter[] pms = new MySqlParameter[3];
            pms[0] = new MySqlParameter("iRM_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iUnit", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iCost", MySqlDbType.Float);
            pms[2].Value = textBox5.Text;

            MySqlCommand cmd = new MySqlCommand("RMC_Update_SP", con);
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
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope. " );
            }
            con.Close();
            Refresh_Data_Grid();
        }//UPDATE TUPLE
    }
}
