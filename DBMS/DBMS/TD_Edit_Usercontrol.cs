﻿using System;
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
    public partial class TD_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static TD_Edit_Usercontrol _instance;
        public static TD_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TD_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public TD_Edit_Usercontrol()
        {
            InitializeComponent();
        }
        public void Refresh_Data_Grid()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("TD_Refresh_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exp2)
                {
                    MessageBox.Show("Error Refreshing the Database.\nException Caught:\n" + exp2);
                }
                con.Close();
                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception exp3)
            {
                MessageBox.Show("Exception Caught:\n" + exp3);
            }
        } //Data Grid Refresh
        private void TD_Edit_Usercontrol_Load(object sender, EventArgs e)
        {
            Refresh_Data_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("iT_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iV_ID", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iDOD", MySqlDbType.Date);
            pms[2].Value = dateTimePicker1.Value.Date;
            pms[3] = new MySqlParameter("iDOA", MySqlDbType.Date);
            pms[3].Value = dateTimePicker2.Value.Date;
            pms[4] = new MySqlParameter("iDO", MySqlDbType.VarChar);
            pms[4].Value = textBox4.Text;



            MySqlCommand cmd = new MySqlCommand("TD_Add_SP", con);
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
            catch (Exception exp24)
            {
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope.\n\n" + exp24);
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
                MySqlCommand cmd = new MySqlCommand("TD_Delete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iT_ID", textBox8.Text);
                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Tuple Deleted");

                    }
                }
                catch (Exception exp6)
                {
                    MessageBox.Show("Error Deleting the tuple.\nPlease verify the Tuple ID to be deleted.");
                }
                con.Close();
            }
            catch (Exception exp10)
            {
                MessageBox.Show("Error Deleting the tuple.\nPlease verify the Tuple ID to be deleted. ");
            }
            Refresh_Data_Grid();
        }//DELETE TUPLE

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("TD_Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("iT_ID", textBox1.Text);
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exp2)
                {
                    MessageBox.Show("Error Refreshing the Database.\nException Caught:\n" + exp2);
                }

                con.Close();
                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception exp3)
            {
                MessageBox.Show("Exception Caught:\n" + exp3);
            }

            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("TD_Search_SP", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("iT_ID", textBox1.Text);
                MySqlDataReader dr = cmd1.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        string eid = dr.GetString("Transport_ID");
                        textBox8.Text = eid;
                        string ene = dr.GetString("Vehicle_ID");
                        textBox7.Text = ene;
                        string dob = dr.GetDateTime("Date_Of_Departure").ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(dob);
                        string des = dr.GetDateTime("Date_Of_Arrival").ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(des);
                        string adr = dr.GetString("Driver/Operator");
                        textBox4.Text = adr;
                        

                    }
                }
                catch (Exception exp20)
                {
                    MessageBox.Show("inner" + exp20);
                }

            }
            catch (Exception exp21)
            {
                MessageBox.Show("" + exp21);
            }
            con.Close();
        }//SEARCH TUPLE

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("iT_ID", MySqlDbType.VarChar);
            pms[0].Value = textBox8.Text;
            pms[1] = new MySqlParameter("iV_ID", MySqlDbType.VarChar);
            pms[1].Value = textBox7.Text;
            pms[2] = new MySqlParameter("iDOD", MySqlDbType.Date);
            pms[2].Value = dateTimePicker1.Value.Date;
            pms[3] = new MySqlParameter("iDOA", MySqlDbType.Date);
            pms[3].Value = dateTimePicker2.Value.Date;
            pms[4] = new MySqlParameter("iDO", MySqlDbType.VarChar);
            pms[4].Value = textBox4.Text;
            

            MySqlCommand cmd = new MySqlCommand("TD_Update_SP", con);
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
            catch (Exception exp)
            {
                MessageBox.Show("Invalid Entries.\nPlease Check The Entries.\nPossible Scope/s of Error:\n1)Primary key violation.\n2)Foreign key match not found.\n3)Variable length out of Scope. "+exp);
            }
            con.Close();
            Refresh_Data_Grid();
        }
    }
}