﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseManagmentSystem.Model;

namespace CourseManagmentSystem.Views
{
    public partial class AssessmentSubmission : Form
    {
        private string username;
        string filePath;
        string fullFilePath;
        public AssessmentSubmission(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files|*.*|PDF Files|*.pdf|Word Documents|*.docx";

            if (open.ShowDialog() == DialogResult.OK)
            {
                filePath = open.FileName;

                string relativeDirectory = "Submissions";
                string filename = Path.GetFileName(filePath);

                string relativeFilePath = Path.Combine(relativeDirectory, filename);

                string fullDirectoryPath = Path.Combine(Application.StartupPath, relativeDirectory);

                if (!Directory.Exists(fullDirectoryPath))
                {
                    Directory.CreateDirectory(fullDirectoryPath);
                }

                fullFilePath = Path.Combine(fullDirectoryPath, filename);

                label4.Text = Path.GetFileName(filePath);

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
