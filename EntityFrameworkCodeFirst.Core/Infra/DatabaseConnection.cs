using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace EntityFrameworkCodeFirst.Core.Infra
{
    public class DatabaseConnection : DropCreateDatabaseAlways<DbContext>, IDisposable
    {
        public DbContext Context { get; private set; }

        public DatabaseConnection()
        {
            this.Context = new EntityFrameworkContext();
            Database.SetInitializer<DbContext>(new DropCreateDatabaseAlways<DbContext>());
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }

    public class EntityFrameworkContext : DbContext, IDisposable
    {
        public EntityFrameworkContext() : base("schoolMySQL") {
            
        }

        public DbSet<Model.Course> Courses {get;set;}
        public DbSet<Model.Student> Students {get;set;}
        public DbSet<Model.Enrollment> Enrollments {get;set;}

        public void Dispose()
        {
            
            this.Dispose();
        }
    }
}
