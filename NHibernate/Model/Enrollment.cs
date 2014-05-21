using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

namespace NHibernateTutorial.Core.Model
{
    public class Enrollment
    {
        public virtual int Id { get; protected set; }
        public virtual Student Student { get; set; }
        public virtual DateTime Date { get; set; }

        protected Enrollment(){}

        public Enrollment(Student student, DateTime date)
        {
            this.Student = student;
            this.Date = date;
        }

        public class EnrollmentMap : ClassMap<Enrollment>
        {
            public EnrollmentMap()
            {
                Table("enrollment");

                Id(i => i.Id);
                Map(x => x.Date);

                References(x => x.Student).Column("studentid");
            }
        }

    }
}
