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

        public List<Assessment> getAssessmnetsOfCourse(string code)
        {
            Course course = new CourseController().GetCourse(code);

            try
            {
                using (AppDbContext db = new AppDbContext()) 
                {
                    List<Assessment> assessment = db.Assessments.Where(a => a.Course == course).ToList();

                    return assessment;
                }
            }
            catch (Exception e) { 
                MessageBox.Show(e.Message);

                return null;
            }

        }

        public Assessment getfromname(string name)
        {
            using (var db = new AppDbContext())
            {
                return db.Assessments.Where(c => c.Name == name).FirstOrDefault();
            }
        }
    }
}
