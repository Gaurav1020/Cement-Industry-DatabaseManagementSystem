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
    public partial class About_Edit_Usercontrol : UserControl
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1;Database=cement_industry;Uid=root;Pwd=1020");

        private static About_Edit_Usercontrol _instance;
        public static About_Edit_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new About_Edit_Usercontrol();

                }
                return _instance;
            }
        }
        public About_Edit_Usercontrol()
        {
            InitializeComponent();
        }

        private void About_Edit_Usercontrol_Load(object sender, EventArgs e)
        {

        }


    }
}
