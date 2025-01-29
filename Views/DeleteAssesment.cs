using CourseManagmentSystem.Controller;
using CourseManagmentSystem.Model;
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
    public partial class DeleteAssesment : Form
    {
        private string username;
        public DeleteAssesment(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void DeleteAssesment_Load(object sender, EventArgs e)
        {
            CourseController coursecontroller = new CourseController();
            List<Course> courses = coursecontroller.GetCourses(username);

            foreach (Course course in courses)
            {
                comboBox1.Items.Add(course.Code);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cname = comboBox1.Text;
            string aname = comboBox2.Text;

            AssessmentController assessmentController = new AssessmentController();
            assessmentController.RemoveAssesment(cname, aname);

            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = comboBox1.Text;

            //get the Assesments in the course
            AssessmentController controller = new AssessmentController();
            List<Assessment> assessments = controller.getAssessmnetsOfCourse(code);

            foreach (Assessment assessment in assessments)
            {
                comboBox2.Items.Add(assessment.Name);
            }
        }
    }
}
