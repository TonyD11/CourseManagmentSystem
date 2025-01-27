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
    public partial class EditCourse : Form
    {
        public string username;
        Controller.CourseController courseController = new Controller.CourseController();

        public EditCourse(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void EditCourse_Load(object sender, EventArgs e)
        {
            List<Model.Course> courses = courseController.GetCourses(username);

            foreach (Model.Course course in courses)
            {
                comboBox1.Items.Add(course.Code);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course course = courseController.GetCourse(comboBox1.Text);

            textBox1.Text = course.Name;
            textBox3.Text = course.Description;
            textBox4.Text = course.Duration;
            textBox5.Text = course.Syllabus;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = comboBox1.Text;
            string name = textBox1.Text;
            string description = textBox3.Text;
            string duration = textBox4.Text;
            string syllabus = textBox5.Text;

            Course course = new Course(name, code, description, username, duration, syllabus);

            courseController.UpdateCourse(course);

            this.Close();
        }
    }
}
