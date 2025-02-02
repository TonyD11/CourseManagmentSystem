using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Controller
{
    internal class SubmissionController
    {
        public void CreateSubmission(Submissions submission)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Users.Attach(submission.User);
                db.Assessments.Attach(submission.Assessment);

                db.Submissions.Add(submission);

                db.SaveChanges();

                MessageBox.Show("Submission is completed");

            }
        }
    }
}
