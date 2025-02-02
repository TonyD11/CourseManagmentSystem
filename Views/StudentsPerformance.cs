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
    public partial class StudentsPerformance : Form
    {
        private string username;
        public StudentsPerformance(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void StudentsPerformance_Load(object sender, EventArgs e)
        {
            UserController userController = new UserController();

            List<User> users = userController.GetStudents();

            foreach (User user in users)
            {
                comboBox1.Items.Add(user.Username);
            }
        }
    }
}
