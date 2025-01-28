using CourseManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem.Controller
{
    internal class AssessmentController
    {
        public bool CreateAssesment(Assessment assessment)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    db.Assessments.Add(assessment);
                    db.SaveChanges();

                    MessageBox.Show("Assessment created successfully!");

                    return true;

                }
                catch (Exception e)
                {
                    MessageBox.Show($"An error occured while creating the Assesment {e.Message}");
                    return false;
                }

            }
        }
    }
}
