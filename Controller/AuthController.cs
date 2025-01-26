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
        public bool CreateUser(User user)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("User created successfully!");

                    return true;

                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured while creating the user");
                    return false;
                }
                
            }
        }

        public string Login(string username, string password)
        {
           
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    User user = db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
                    if (user != null)
                    {
                        MessageBox.Show($"Welcom {user.Username}");
                        return user.Role;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                        return "null";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured while logging in");
                    return "null";
                }
            }
        }
    }
}
