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
                comboBox1.Items.Add(course.Name);
            }
        }
    }
}
