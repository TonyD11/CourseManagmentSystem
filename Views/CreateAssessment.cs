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
    public partial class CreateAssessment : Form
    {
        public string username;
        public CreateAssessment(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void CreateAssessment_Load(object sender, EventArgs e)
        {
            CourseController coursecontroller = new CourseController();
            List<Course> courses = coursecontroller.GetCourses(username);

            foreach (Course course in courses)
            {
                comboBox1.Items.Add(course.Code);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = comboBox1.Text;
            string name = textBox1.Text;
            string discription = textBox2.Text;
            DateTime due = dateTimePicker1.Value;

            CourseController coursecontroller = new CourseController();
            Course course = coursecontroller.GetCourse(code);

            Assessment assessment = new Assessment(course, name, discription, due);

            AssessmentController assessmentController = new AssessmentController();
            assessmentController.CreateAssesment(assessment);

            this.Hide();

        }
    }
}
