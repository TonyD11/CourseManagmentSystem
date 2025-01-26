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
    }
}
