using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using NHibernateTutorial.Core.Model;
using NHibernateTutorial.Core.Infra;

namespace NHibernateTutorial.Test
{
    [TestClass, Ignore]
    public class CourseTest
    {
        private DatabaseConnection database = new DatabaseConnection();

        [TestInitialize]
        public void Initialize()
        {
            Repository<Course> repository = new Repository<Course>(database);
            var courseList = repository.GetAll();

            foreach (var course in courseList)
            { 
                if(course.Students != null && course.Students.Count > 0)
                repository.Delete(course);
            }
        }

        [TestMethod]
        public void CreateCourse()
        {
            var course = new Course("Mathematics");
            Repository<Course> repository = new Repository<Course>(database);
            repository.Save(course);

            Assert.AreNotEqual(0, course.Id);
        }

        [TestMethod]
        public void AddStudentToCourse()
        {
            Repository<Course> repository = new Repository<Course>(database);
            Repository<Student> repository2 = new Repository<Student>(database);

            var student = new Student("Newbie student");
            repository2.Save(student);

            var course = new Course("French");
            course.Students.Add(student);

            repository.Save(course);
        }
    }
}
