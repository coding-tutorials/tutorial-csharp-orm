﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDatabaseFirst.Core.Model
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

}