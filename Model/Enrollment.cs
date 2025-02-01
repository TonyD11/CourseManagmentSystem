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
        public Enrollment() { }
        public Enrollment(User user, Course course)
        {
            User = user;
            Course = course;
            Status = "Pending";
        }

        public int Id { get; set; }
        public virtual User User { get; set; }  // Use virtual for lazy loading
        public virtual Course Course { get; set; }
        public string Status { get; set; }
    }
}
