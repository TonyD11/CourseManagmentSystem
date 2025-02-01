using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
                // Get all courses taught by the given instructor
                List<Course> courses = db.Courses.Where(c => c.Instructor == username).ToList();

                // Initialize the DataTable
                DataTable requests = new DataTable();
                requests.Columns.Add("Student Name", typeof(string));
                requests.Columns.Add("Course Name", typeof(string));

                // Loop through each course taught by the instructor
                foreach (Course course in courses)
                {
                    try
                    {
                        // Fetch only enrollments for this course with "Pending" status
                        List<Enrollment> pendingEnrollments = db.Enrollments
                                                        .Include(e => e.User) // Eagerly load User
                                                        .Include(e => e.Course) // Eagerly load Course
                                                        .Where(e => e.Course.Id == course.Id && e.Status == "Pending")
                                                        .ToList();

                        // Add each enrollment's details to the DataTable
                        foreach (Enrollment enrollment in pendingEnrollments)
                        {
                            requests.Rows.Add(enrollment.User.Username, enrollment.Course.Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing enrollments for course {course.Name}: {ex.Message}");
                    }
                }
                return requests;
            }
        }
        public void createEnrollment(Enrollment enrollment)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Courses.Attach(enrollment.Course);
                db.Users.Attach(enrollment.User);

                db.Enrollments.Add(enrollment);
                db.SaveChanges();

                MessageBox.Show("Enrollment Has been Requested");
            }
        }
    }
}
