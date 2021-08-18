using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class EditWindow : Form
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void EditWindow_Load(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrEdit obj = new ViewOrEdit();
            obj.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Project_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(Project_Edit_Usercontrol.Instance);
                Project_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                Project_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Project_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(EPD_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(EPD_Edit_Usercontrol.Instance);
                EPD_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                EPD_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                EPD_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(ECD_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(ECD_Edit_Usercontrol.Instance);
                ECD_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                ECD_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                ECD_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Departments_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(Departments_Edit_Usercontrol.Instance);
                Departments_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                Departments_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Departments_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(EOP_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(EOP_Edit_Usercontrol.Instance);
                EOP_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                EOP_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                EOP_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Supplier_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(Supplier_Edit_Usercontrol.Instance);
                Supplier_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                Supplier_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Supplier_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(SL_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(SL_Edit_Usercontrol.Instance);
                SL_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                SL_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                SL_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Machinery_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(Machinery_Edit_Usercontrol.Instance);
                Machinery_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                Machinery_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Machinery_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(MC_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(MC_Edit_Usercontrol.Instance);
                MC_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                MC_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                MC_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(RM_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(RM_Edit_Usercontrol.Instance);
                RM_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                RM_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                RM_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(RMC_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(RMC_Edit_Usercontrol.Instance);
                RMC_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                RMC_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                RMC_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Logistics_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(Logistics_Edit_Usercontrol.Instance);
                Logistics_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                Logistics_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Logistics_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(C_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(C_Edit_Usercontrol.Instance);
                C_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                C_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                C_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(CF_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(CF_Edit_Usercontrol.Instance);
                CF_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                CF_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                CF_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(CP_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(CP_Edit_Usercontrol.Instance);
                CP_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                CP_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                CP_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(MGP_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(MGP_Edit_Usercontrol.Instance);
                MGP_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                MGP_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                MGP_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(TD_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(TD_Edit_Usercontrol.Instance);
                TD_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                TD_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                TD_Edit_Usercontrol.Instance.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(About_Edit_Usercontrol.Instance))
            {
                panel2.Controls.Add(About_Edit_Usercontrol.Instance);
                About_Edit_Usercontrol.Instance.Dock = DockStyle.Fill;
                About_Edit_Usercontrol.Instance.BringToFront();
            }
            else
            {
                About_Edit_Usercontrol.Instance.BringToFront();
            }
        }
    }
    
}
