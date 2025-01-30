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
    public partial class EnrollmentRequest : Form
    {
        public string username;
        public EnrollmentRequest(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void EnrollmentRequest_Load(object sender, EventArgs e)
        {
            
        }
    }
}
