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

        public Student(){}

        public Student(string name)
        {
            this.Name = name;
        }
    }

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            
            Table("student");

            Id(i => i.Id);
            Map(x => x.Name);
        }
    }
}
