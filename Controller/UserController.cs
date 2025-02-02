using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void UpdateUser(User user, int userid) 
        {
            using (AppDbContext db = new AppDbContext())
            {
                User userDetails = db.Users.Where(u => u.Id == userid).FirstOrDefault();

                userDetails.Username = user.Username;
                userDetails.Password = user.Password;
                userDetails.Email = user.Email;

                db.SaveChanges();
                MessageBox.Show("User Details Changed");
            }
        }

        public List<User> GetStudents() 
        {
            using(AppDbContext db = new AppDbContext())
            {
                List<User> users = db.Users.Where(u => u.Role == "student").ToList();

                return users;
            }
        }
    }
}
