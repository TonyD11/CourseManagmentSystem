using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem.Model
{
    internal class Course
    {
        public Course()
        {
        }
        public Course(string name, string code, string description, string instructor, string duration, string syllabus)
        {
            Name = name;
            Code = code;
            Description = description;
            Instructor = instructor;
            Duration = duration;
            Syllabus = syllabus;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string Instructor { get; set; }

        public string Duration { get; set; }

        public string Syllabus { get; set; }
    }
}
