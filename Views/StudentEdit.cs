using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Controller;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Views
{
    public partial class StudentEdit : Form
    {
        private string username;
        private int userid;
        public StudentEdit(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void StudentEdit_Load(object sender, EventArgs e)
        {
            UserController userController = new UserController();

            User details = userController.getUserDetails(username);

            textBox1.Text = details.Username;
            textBox2.Text = details.Password;
            textBox4.Text = details.Email;

            userid = details.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox4.Text;

            Student student = new Student(user, password,email);

            UserController userController = new UserController();
            userController.UpdateUser(student, userid);

            if(username != user)
            {
                MessageBox.Show("You are being logged out");
                this.Hide();
                new Login().Show();
            }

            this.Hide();

        }
    }
}
