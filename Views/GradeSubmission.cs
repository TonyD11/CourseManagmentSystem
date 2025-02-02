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
    public partial class GradeSubmission : Form
    {
        public GradeSubmission()
        {
            InitializeComponent();
        }

        List<Submissions> submissions;

        private void GradeSubmission_Load(object sender, EventArgs e)
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
                if (assessment.DueDate > DateTime.Now)
                {
                    comboBox2.Items.Add(assessment.Name);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ass = comboBox2.Text;

            AssessmentController assessmentController = new AssessmentController();
            Assessment assessment = assessmentController.getfromname(ass);

            SubmissionController submissionController = new SubmissionController();
            submissions = submissionController.submissions(assessment);

            foreach (Submissions submission in submissions)
            {
                comboBox3.Items.Add(submission.User.Username);
            }


        }
    }
}
