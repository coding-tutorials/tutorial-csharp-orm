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
    public class StudentTest
    {

        [TestInitialize]
        public void Initialize()
        {
            Repository<Student> repository = new Repository<Student>();
            var students = repository.GetAll();

            foreach(var student in students)
                repository.Delete(student);
        }

        [TestMethod]
        public void CreateStudent()
        {
            Student  newStudent = new Student("Julius Prest");
            Repository<Student> repository = new Repository<Student>();
            repository.Save(newStudent);

            Assert.AreNotEqual(0, newStudent.Id);
        }

        [TestMethod]
        public void EditStudent()
        {
            string originalName = "Original Name";

            Student testStudent = new Student(originalName);
            Repository<Student> repository = new Repository<Student>();
            repository.Save(testStudent);

            Student searchStudent = repository.GetWhere(student => student.Name == originalName).First();
            searchStudent.Name = "John Travolta";
            repository.Save(searchStudent);

            Student editedStudent = repository.GetWhere(student => student.Id == testStudent.Id).First();

            Assert.AreNotEqual(originalName, editedStudent.Name);
        }

        [TestMethod, Ignore]
        public void ListStudentCourses()
        {
            var repositoryCourse = new Repository<Course>();
            var course1 = new Course("Mathematics");
            repositoryCourse.Save(course1);
            var course2 = new Course("History");
            repositoryCourse.Save(course2);
            var course3 = new Course("Geometry");
            repositoryCourse.Save(course3);

            var student = new Student("Marco Roger");
            student.Courses.Add(course1);
            student.Courses.Add(course2);
            student.Courses.Add(course3);

            var repositoryStudent = new Repository<Student>();
            repositoryStudent.Save(student);

            var searchStudend = repositoryStudent.GetWhere(s => s.Name == "Marco Roger").First();
            searchStudend.Courses.Count.Should().Be(3);
        }
    }
}
