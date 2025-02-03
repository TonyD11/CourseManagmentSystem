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
    public partial class ViewProgress : Form
    {
        private string _username;
        public ViewProgress(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void ViewProgress_Load(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            User user = userController.getUserDetails(_username);

            SubmissionController submissionController = new SubmissionController();
            List<Submissions> submissions = submissionController.usersSubmission(user);

            dataGridView1.DataSource = submissions;
        }
    }
}
