using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Controller;

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
            EnrollmentController enrollmentController = new EnrollmentController();
            DataTable dataTable = enrollmentController.getAllEnrollemtRequest(username);

            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
