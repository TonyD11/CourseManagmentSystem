using CourseManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    internal class AppDbContext : DbContext 
    {
        public AppDbContext() : base("name=MySqlConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

    
}
