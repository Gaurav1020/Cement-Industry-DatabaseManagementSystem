using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySqlConnector;

namespace DBMS
{
    public partial class LogIN : Form
    {
        public LogIN()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");
        MySqlCommand cmd;
        MySqlDataReader dr;
        private String getUsername()
        {
            try
            {
                con.Open();
                String syntax = "SELECT Username from admins where id=1";
                cmd = new MySqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String temp = dr[0].ToString();
                con.Close();
                return temp;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection to database failed due to:\n1) MySQL Database Not Found.\n2) MySQL 'root' user password mismatch.\nPlease Check the readme doc again and verify everything is set properly and matching.");
                return (null);
            }
        }

        private String getPassword()
        {
            try
            {
                con.Open();
                String syntax = "SELECT Password from admins where id=1";
                cmd = new MySqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String temp = dr[0].ToString();
                con.Close();
                return temp;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection to database failed due to:\n1) MySQL Database Not Found.\n2) MySQL 'root' user password mismatch.\nPlease Check the readme doc again and verify everything is set properly and matching.");
                return (null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Uname = getUsername(), Upass = getPassword(), name, pass;
            name = textBox2.Text;
            pass = textBox1.Text;
            
            if (name.Equals(Uname) && Upass.Equals(pass))
            {
                //Login
                label3.Hide();
                MessageBox.Show("Login Successful\nWelcome " + getUsername());
                ViewOrEdit obj = new ViewOrEdit();
                this.Hide();
                obj.Show();


            }
            else
            {
                //Dont login
                label3.Show();
                textBox1.ResetText();
                textBox2.ResetText();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
