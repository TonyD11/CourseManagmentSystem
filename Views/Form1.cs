using CourseManagmentSystem.Model;
using CourseManagmentSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string cpassword = textBox3.Text;
            string email = textBox4.Text;
            string role= comboBox1.Text;


            bool created = false;

            if (password != cpassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            if (username.Length < 5)
            {
                MessageBox.Show("Username must be at least 5 characters long");
                return;
            }

            if (password.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters long");
                return;
            }

            if(username == "" || password == "" || email == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            if (role == "")
            {
                MessageBox.Show("Please select a role");
                return;
            }

            if (role == "instructor")
            {
                Model.Instructor instructor = new Model.Instructor(username, password, email);
                 // Create a new AuthController
                Controller.AuthController authController = new Controller.AuthController();

                // Call the CreateUser method
                created = authController.CreateUser(instructor);
                
            }
            if (role == "student")
            {
                Model.Student student = new Model.Student(username, password, email);


                // Create a new AuthController
                Controller.AuthController authController = new Controller.AuthController();

                // Call the CreateUser method
                created = authController.CreateUser(student);
            }

            if (created)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }

        }
    }
}
