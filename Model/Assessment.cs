using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem.Model
{
    internal class Assessment
    {
        public Assessment() { }
        public Assessment(Course course, string name, string description, DateTime dueDate)
        {
            
            Course = course;
            Name = name;
            Description = description;
            DueDate = dueDate;
        }

        public int Id { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

    }
}
