using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Views
{
    public partial class DeleteCourse : Form
    {
        public string username;
        private Controller.CourseController courseController = new Controller.CourseController();
        public DeleteCourse(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void DeleteCourse_Load(object sender, EventArgs e)
        {
            List<Course> courses = courseController.GetCourses(username);

            foreach (Course course in courses)
            {
                comboBox1.Items.Add(course.Code);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string code = comboBox1.Text;

            courseController.DeleteCourse(code);

        }
    }
}
