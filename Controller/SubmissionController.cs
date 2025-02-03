using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Model;
using CourseManagmentSystem.Migrations;

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

        public List<Submissions> submissions(Model.Assessment assessment)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Submissions> submissions = db.Submissions
                    .Include(e => e.User)
                    .Include(e => e.Assessment)
                    .Where(s => s.Assessment.Id == assessment.Id)
                    .ToList(); 

                return submissions;
            }
        }

        public void addGrade(decimal grade, int id)
        {
            using (AppDbContext db = new AppDbContext()) {
                Submissions subs = db.Submissions.Where(e  => e.Id == id).FirstOrDefault();

                if (subs != null) 
                {
                    subs.Grade = grade;

                    db.SaveChanges();

                    MessageBox.Show("Grade Has been Added");


                }
            }
        }

        public List<Submissions> usersSubmission(User user)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Submissions> subs = db.Submissions
                                            .Include(e => e.User)
                                            .Include(e => e.Assessment)
                                            .Where(s => s.User.Id == user.Id)
                                            .ToList();

                return subs;
            }
        }
    }
}
