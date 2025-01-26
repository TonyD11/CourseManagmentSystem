using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem.Views
{
    public partial class CreateCourse : Form
    {
        public string username;
        public CreateCourse(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            string courseCode = textBox2.Text;
            string courseDescription = textBox3.Text;
            string courseDuration = textBox4.Text;
            string courseSyallbus = textBox5.Text;
            string instructor = username;

            if (courseName == "" || courseCode == "" || courseDescription == "" || courseDuration == "" || courseSyallbus == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            //Create Course Object
            Model.Course course = new Model.Course(courseName, courseCode, courseDescription, instructor, courseDuration, courseSyallbus);

            // Create a new CourseController
            Controller.CourseController courseController = new Controller.CourseController();

            // Call the CreateCourse method
            courseController.CreateCourse(course);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
    }
}
