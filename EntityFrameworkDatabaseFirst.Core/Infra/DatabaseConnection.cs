using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace EntityFrameworkDatabaseFirst.Core.Infra
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection() : base(){}

        public DbSet<Model.Course> Courses {get;set;}
        public DbSet<Model.Student> Students {get;set;}
        public DbSet<Model.Enrollment> Enrollments {get;set;}

    }
}
