using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

namespace NHibernateTutorial.Core.Model
{
    public class Exam
    {
        public virtual int Id { get; protected set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual int Score { get; set; }

        protected Exam(){}

        public Exam(Student student, Course course, int score)
        {
            this.Student = student;
            this.Course = course;
            this.Score = score;
        }

        public class StudentExamMap : ClassMap<Exam>
        {
            public StudentExamMap()
            {
                Table("exam");

                Id(i => i.Id);
                Map(x => x.Score);

                References(x => x.Student).Column("studentid");
                References(x => x.Course).Column("courseid");
            }
        }

    }
}
