using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernateTutorial.Core.Model;
using NHibernateTutorial.Core.Infra;

namespace NHibernateTutorial.Test
{
    public class TestHelper
    {
        protected Course CreateGenericCourse()
        {
            Repository<Course> courseRepository = new Repository<Course>(new UnityOfWork());
            var course = new Course("Test Course");
            courseRepository.Save(course);
            return course;
        }

        protected Student CreateGenericStudent()
        {
            Repository<Student> courseRepository = new Repository<Student>(new UnityOfWork());
            var student = new Student("Test Student");
            courseRepository.Save(student);
            return student;
        }

    }
}
