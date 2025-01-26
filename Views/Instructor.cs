using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem.Views
{
    public partial class Instructor : Form
    {
        public string username;
        public Instructor(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        public void panelController(object Form)
        {
            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }
            Form frm = Form as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(frm);
            this.panel2.Tag = frm;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelController(new CreateCourse(username));

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panelController(new CreateCourse(username));
        }
    }
}
