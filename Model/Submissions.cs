using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem.Model
{
    internal class Submissions
    {
        public Submissions() { }
        public Submissions(Assessment assessment, User user, DateTime submissionDate, string filePath, string comments)
        {
            Assessment = assessment;
            User = user;
            SubmissionDate = submissionDate;
            FilePath = filePath;
            Comments = comments;
        }

        public int Id { get; set; }
        public virtual Assessment Assessment { get; set; }
        public virtual User User { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string FilePath { get; set; }
        public string Comments { get; set; }
        public decimal? Grade { get; set; }

    }
}
