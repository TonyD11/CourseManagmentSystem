using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            // Create a new AuthController
            Controller.AuthController authController = new Controller.AuthController();

            // Call the Login method
            string role = authController.Login(username, password);

            if (role == "instructor")
            {
                Instructor admin = new Instructor();
                admin.Show();
                this.Hide();
            }
            else if (role == "student")
            {
                Student student = new Student();
                student.Show();
                this.Hide();
            }
        }
    }
}
