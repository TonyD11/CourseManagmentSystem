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
using CourseManagmentSystem.Model;

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
            //get the selected row
            int index = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            if (selectedRow != null)
            {
                string studentName = selectedRow.Cells["Student Name"].Value.ToString();
                string courseName = selectedRow.Cells["Course Name"].Value.ToString();
                // Create a new Enrollment object
                Enrollment enrollment = new Enrollment();
                UserController userController = new UserController();
                enrollment.User = userController.getUserDetails(studentName);

                CourseController courseController = new CourseController();
                enrollment.Course = courseController.GetCourseDetails(courseName);

                enrollment.Status = "Approved";

                // Call the controller to create the enrollment
                EnrollmentController enrollmentController = new EnrollmentController();
                enrollmentController.updateEnrollment(enrollment);


                //reload the page
                EnrollmentRequest_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //decline the request
            int index = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            if (selectedRow != null)
            {
                string studentName = selectedRow.Cells["Student Name"].Value.ToString();
                string courseName = selectedRow.Cells["Course Name"].Value.ToString();
                // Create a new Enrollment object
                Enrollment enrollment = new Enrollment();
                UserController userController = new UserController();
                enrollment.User = userController.getUserDetails(studentName);
                CourseController courseController = new CourseController();
                enrollment.Course = courseController.GetCourseDetails(courseName);
                enrollment.Status = "Declined";
                // Call the controller to create the enrollment
                EnrollmentController enrollmentController = new EnrollmentController();
                enrollmentController.updateEnrollment(enrollment);
                //reload the page
                EnrollmentRequest_Load(sender, e);
            }
        }
    }
}
