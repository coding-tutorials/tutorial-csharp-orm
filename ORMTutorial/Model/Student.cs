using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMTutorial.Model
{
    public class Student
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<Course> Courses { get; set; }
        public virtual IList<Enrollment> Enrollments { get; set; }

        protected Student(){}

        public Student(string name)
        {
            this.Name = name;
            Courses = new List<Course>();
            Enrollments = new List<Enrollment>();
        }
    }

}
