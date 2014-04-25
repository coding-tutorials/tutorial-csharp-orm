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
        public virtual IList<Exam> Exams { get; set; }

        public Student(){}

        public Student(string name)
        {
            this.Name = name;
            Courses = new List<Course>();
            Exams = new List<Exam>();
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
                .Table("coursestudent")
                .ParentKeyColumn("studentid")
                .ChildKeyColumn("courseid");
                //.Inverse() //To be able to delete a student with a course relationship
                //.Cascade
                //.Delete();

            HasMany<Exam>(x => x.Exams)
                .KeyColumn("studentid")
                .Inverse() //To be able to delete a student with a course relationship
                .Cascade
                .Delete();
        }
    }
}
