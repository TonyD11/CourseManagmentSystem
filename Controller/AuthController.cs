using CourseManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem.Controller
{
    internal class AuthController
    {
        public void CreateUser(User user)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

                MessageBox.Show("User created successfully!");
            }
        }
    }
}
