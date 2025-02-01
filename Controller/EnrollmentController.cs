using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Controller
{
    internal class EnrollmentController
    {
        public DataTable getAllEnrollemtRequest(string username)
        {
            using (AppDbContext db = new AppDbContext()) 
            {
                List<Course> courses = db.Courses.Where(c => c.Instructor == username).ToList();

                DataTable requests = new DataTable();

                requests.Columns.Add("Student Name", typeof(string));
                requests.Columns.Add("Course Name", typeof (string));

                foreach (Course course in courses) 
                {
                    try
                    {
                        List<Enrollment> pendingEnrollments = db.Enrollments.Where(c => c.Course_id.Id == course.Id).ToList();
                        foreach (Enrollment enrollment in pendingEnrollments)
                        {
                            requests.Rows.Add(enrollment.User_id.Username, enrollment.Course_id.Name);
                        }

                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }

                    
                   
                }
                return requests;


            }
        }
        public void createEnrollment(Enrollment enrollment)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();

                MessageBox.Show("Enrollment Has been Requested");
            }
        }
    }
}
