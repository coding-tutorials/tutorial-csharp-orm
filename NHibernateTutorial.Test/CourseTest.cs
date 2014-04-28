using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using NHibernateTutorial.Core.Model;
using NHibernateTutorial.Core.Infra;

namespace NHibernateTutorial.Test
{
    [TestClass]
    public class CourseTest
    {
        private DatabaseConnection database = new DatabaseConnection();

        [TestInitialize]
        public void Initialize()
        {
            Repository<Course> courseRepository = new Repository<Course>(database);
            var courseList = courseRepository.GetAll();

            foreach (var course in courseList)
                courseRepository.Delete(course);
        }

        [TestMethod]
        public void CourseCreate()
        {
            Repository<Course> courseRepository = new Repository<Course>(database);
            var course = new Course("Mathematics");
            courseRepository.Save(course);

            Assert.AreNotEqual(0, course.Id);
        }

        [TestMethod]
        public void CourseEdit()
        {
            Repository<Course> courseRepository = new Repository<Course>(database);
            var course = new Course("Mathematics");
            courseRepository.Save(course);

            var courseEdit = courseRepository.GetWhere(c => c.Id == course.Id).First();
            courseEdit.Name = "Physics";
            courseRepository.Save(courseEdit);

            var checkEditedCourse = courseRepository.GetWhere(c => c.Id == courseEdit.Id).First();
            checkEditedCourse.Should().NotBe(course.Name);
        }

        [TestMethod]
        public void CourseAddStudent()
        {
            Repository<Course> courseRepository = new Repository<Course>(database);
            Repository<Student> studentRepository = new Repository<Student>(database);

            var student = new Student("Newbie student");
            studentRepository.Save(student);

            var course = new Course("French");
            course.Students.Add(student);

            courseRepository.Save(course);
        }

        [TestMethod]
        public void CourseDeleteWithStudent()
        {
            Repository<Course> courseRepository = new Repository<Course>(database);
            Repository<Student> studentRepository = new Repository<Student>(database);

            var student = new Student("Newbie student");
            studentRepository.Save(student);
            int studentId = student.Id;

            var course = new Course("French");
            course.Students.Add(student);
            courseRepository.Save(course);

            courseRepository.Delete(course);

            var checkStudentStillExists = studentRepository.GetWhere(s => s.Id == studentId).First();

            checkStudentStillExists.Name.Should().Be(student.Name);
        }

        [TestCleanup]
        public void Dispose()
        {
            this.database.Dispose();
        }
    }
}
