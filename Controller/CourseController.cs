using CourseManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem.Controller
{
    internal class CourseController
    {
        // Create a new course
        public void CreateCourse(Course course)
        {
            using (var db = new AppDbContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();

                MessageBox.Show("Course Created Successfully");
            }
        }

        // Get all courses of the instructor
        public List<Course> GetCourses(string instructor)
        {
            using (var db = new AppDbContext())
            {
                return db.Courses.Where(c => c.Instructor == instructor).ToList();
            }
        }

        // Get course by code
        public Course GetCourse(string code)
        {
            using (var db = new AppDbContext())
            {
                return db.Courses.Where(c => c.Code == code).FirstOrDefault();
            }
        }

        // Update course
        public void UpdateCourse(Course course)
        {
            using (var db = new AppDbContext())
            {
                Course courseToUpdate = db.Courses.Where(c => c.Code == course.Code).FirstOrDefault();
                courseToUpdate.Name = course.Name;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Duration = course.Duration;
                courseToUpdate.Syllabus = course.Syllabus;
                db.SaveChanges();
                MessageBox.Show("Course Updated Successfully");
            }
        }
    }
}
