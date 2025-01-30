using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Crud;

namespace CourseManagmentSystem.Model
{
    internal class Enrollment
    {
        public Enrollment(User user_id, Course course_id)
        {
            User_id = user_id;
            Course_id = course_id;
            Status = "Pending";
        }

        public int Id { get; set; }
        public User User_id { get; set; }
        public Course Course_id { get; set; }
        public string Status { get; set; }
    }
}
