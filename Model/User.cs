using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem.Model
{
    internal class User
    {
        private string _username;
        private string _password;
        private string _email;
        private string _role;

        public User(string userName, string password, string email, string role)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Role = role;
        }

        public string UserName { 
            get { return _username; }
            set { _username = value; }
        }

        public string Password { 
            get { return _password;}
            set { _password = value; } 
        }

        public string Email {
            get { return _email;}
            set { _email = value; }
        }

        public string Role {
            get { return _role;}
            set { _role = value; } 
        }
    }
}
