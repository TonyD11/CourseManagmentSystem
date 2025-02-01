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
    public partial class EnrollmentForm : Form
    {
        public string username;
        CourseController controller = new CourseController();
        public EnrollmentForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {
            List<Course> course = controller.GetCourseList();

            comboBox1.DataSource = course;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Course corurse = comboBox1.SelectedItem as Course;

            //Get the iser details
            UserController usercontroller = new UserController();
            User user = usercontroller.getUserDetails(username);

            Enrollment enrollment = new Enrollment(user, corurse);

            EnrollmentController Enrolcontroller = new EnrollmentController();

            Enrolcontroller.createEnrollment(enrollment);
        }
    }
}
