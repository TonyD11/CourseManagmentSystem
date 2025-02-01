using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Controller
{
    internal class UserController
    {
        public User getUserDetails(string username)
        {
            using (AppDbContext db = new AppDbContext()) 
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);

                return user;
            }
        }
    }
}
