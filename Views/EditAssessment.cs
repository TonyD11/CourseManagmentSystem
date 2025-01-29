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
    public partial class EditAssessment : Form
    {
        private string username;
        public EditAssessment(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void EditAssessment_Load(object sender, EventArgs e)
        {
            CourseController coursecontroller = new CourseController();
            List<Course> courses = coursecontroller.GetCourses(username);

            foreach (Course course in courses)
            {
                comboBox1.Items.Add(course.Code);
            }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboBox2.Text;

            AssessmentController assessmentcontroller = new AssessmentController();

            Assessment assessment = assessmentcontroller.getfromname(name);

            dateTimePicker1.Value = assessment.DueDate.ToLocalTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cname = comboBox1.Text;
            string name = comboBox2.Text;
            DateTime newdate = dateTimePicker1.Value;

            AssessmentController assessmentController = new AssessmentController();
            assessmentController.UpdateAssesment(cname, name, newdate);

        }
    }
}
