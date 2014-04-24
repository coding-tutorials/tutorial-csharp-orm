using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using FluentAssertions;

using NHibernateTutorial.Core.Model;
using NHibernateTutorial.Core.Infra;

namespace NHibernateTutorial.Test
{
    [TestClass]
    public class CourseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Repository<Course> repository = new Repository<Course>();
            var courses = repository.GetAll();

            //foreach (var course in courses)
                //repository.Delete(course);
        }

        [TestMethod]
        public void CreateCourse()
        {
            var course = new Course("Mathematics");
            Repository<Course> repository = new Repository<Course>();
            repository.Save(course);

            Assert.AreNotEqual(0, course.Id);
        }

        [TestMethod, Ignore]
        public void AddStudentToCourse()
        {
            Repository<Course> repository = new Repository<Course>();
            Repository<Student> repository2 = new Repository<Student>();

            var student = new Student("Newbie student");
            repository2.Save(student);

            var course = new Course("French");
            course.Students.Add(student);

            repository.Save(course);
        }
    }
}
