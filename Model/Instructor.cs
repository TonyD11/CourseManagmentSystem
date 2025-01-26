using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem.Model
{
    internal class Instructor : User
    {
        public Instructor(string username, string password, string email) : base(username, password, email)
        {
            Role = "instructor";
        }


    }
}
