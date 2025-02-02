using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Controller;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Views
{
    public partial class AssessmentSubmission : Form
    {
        private string username;
        string filePath;
        string fullFilePath;
        public AssessmentSubmission(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files|*.*|PDF Files|*.pdf|Word Documents|*.docx";

            if (open.ShowDialog() == DialogResult.OK)
            {
                filePath = open.FileName;

                string relativeDirectory = "Submissions";
                string filename = Path.GetFileName(filePath);

                string relativeFilePath = Path.Combine(relativeDirectory, filename);

                string fullDirectoryPath = Path.Combine(Application.StartupPath, relativeDirectory);

                if (!Directory.Exists(fullDirectoryPath))
                {
                    Directory.CreateDirectory(fullDirectoryPath);
                }

                fullFilePath = Path.Combine(fullDirectoryPath, filename);

                label4.Text = Path.GetFileName(filePath);

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AssessmentSubmission_Load(object sender, EventArgs e)
        {
            CourseController courseController = new CourseController();
            List<Course> courses = courseController.GetCourseList();

            foreach (Course course in courses)
            {
                comboBox1.Items.Add(course.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get all assignments that are in the course that are not due

            string courseName = comboBox1.Text;

            CourseController courseController1 = new CourseController();
            Course course = courseController1.GetCourse(courseName);

            AssessmentController assessmentController = new AssessmentController();
            List<Assessment> assessments = assessmentController.getAssessmnetsOfCourse(course.Code);

            foreach (Assessment assessment in assessments)
            {
                if(assessment.DueDate > DateTime.Now)
                {
                    comboBox2.Items.Add(assessment.Name);
                }
            }
        }
    }
}
