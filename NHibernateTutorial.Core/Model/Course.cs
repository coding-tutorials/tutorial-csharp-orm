using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

namespace NHibernateTutorial.Core.Model
{
    public class Course
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Student> Students { get; set; }

        public Course() { }

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        } 
    }

    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("course");

            Id(i => i.Id);
            Map(x => x.Name);

            HasManyToMany<Student>(x => x.Students)
            .Table("coursestudent")
            .ParentKeyColumn("courseid")
            .ChildKeyColumn("studentid")
            .Cascade
            .None();
        }
    }
}
