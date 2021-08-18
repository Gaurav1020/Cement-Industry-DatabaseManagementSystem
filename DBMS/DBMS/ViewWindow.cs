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
    public partial class ViewWindow : Form
    {
        public ViewWindow()
        {
            InitializeComponent();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOrEdit obj = new ViewOrEdit();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Project_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(Project_View_Usercontrol.Instance);
                Project_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                Project_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Project_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Employee_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(Employee_View_Usercontrol.Instance);
                Employee_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                Employee_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Employee_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Dept_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(Dept_View_Usercontrol.Instance);
                Dept_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                Dept_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Dept_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Supp_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(Supp_View_Usercontrol.Instance);
                Supp_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                Supp_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Supp_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Mach_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(Mach_View_Usercontrol.Instance);
                Mach_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                Mach_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                Mach_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(RM_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(RM_View_Usercontrol.Instance);
                RM_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                RM_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                RM_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(L_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(L_View_Usercontrol.Instance);
                L_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                L_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                L_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(C_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(C_View_Usercontrol.Instance);
                C_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                C_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                C_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(CP_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(CP_View_Usercontrol.Instance);
                CP_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                CP_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                CP_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(MGP_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(MGP_View_Usercontrol.Instance);
                MGP_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                MGP_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                MGP_View_Usercontrol.Instance.BringToFront();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(TD_View_Usercontrol.Instance))
            {
                panel2.Controls.Add(TD_View_Usercontrol.Instance);
                TD_View_Usercontrol.Instance.Dock = DockStyle.Fill;
                TD_View_Usercontrol.Instance.BringToFront();
            }
            else
            {
                TD_View_Usercontrol.Instance.BringToFront();
            }
        }
    }
    
}
