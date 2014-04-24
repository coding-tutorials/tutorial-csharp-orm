using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

namespace NHibernateTutorial.Core.Model
{
    public class Student
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Course> Courses { get; set; }

        public Student(){
        }

        public Student(string name)
        {
            this.Name = name;
            Courses = new List<Course>();
        }
    }

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            
            Table("student");

            Id(i => i.Id);
            Map(x => x.Name);

            HasManyToMany<Course>(x => x.Courses)
            .Table("course_student")
            .ParentKeyColumn("studentid")
            .NotFound.Ignore()
            .ChildKeyColumn("courseid")
            .NotFound.Ignore()
            .Cascade
            .All();
        }
    }
}
