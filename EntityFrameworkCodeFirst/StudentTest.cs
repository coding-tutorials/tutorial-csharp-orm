using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using EntityFrameworkCodeFirst.Core.Model;
using EntityFrameworkCodeFirst.Core.Infra;

namespace EntityFrameworkCodeFirst.Test
{
    [TestClass]
    public class StudentTest
    {
        private DatabaseConnection database = new DatabaseConnection();

        [TestInitialize]
        public void Initialize()
        {
            Repository<Student> studentRepository = new Repository<Student>(database);

            var studentList = studentRepository.GetAll().ToList();

            foreach(var student in studentList.ToList())
                studentRepository.Delete(student);
        }

        [TestCleanup]
        public void Dispose()
        {
            this.database.Dispose();
        }

        [TestMethod]
        public void StudentCreate()
        {
            Student  student = new Student("Julius Prest");
            Repository<Student> repositoryStudent = new Repository<Student>(database);
            repositoryStudent.Save(student);

            Assert.AreNotEqual(0, student.Id);
        }

        [TestMethod]
        public void StudentEdit()
        {
            string originalName = "Original Name";

            Student testStudent = new Student(originalName);
            Repository<Student> repository = new Repository<Student>(database);
            repository.Save(testStudent);

            Student searchStudent = repository.GetWhere(student => student.Name == originalName).First();
            searchStudent.Name = "John Travolta";
            repository.Save(searchStudent);

            Student editedStudent = repository.GetWhere(student => student.Id == testStudent.Id).First();

            Assert.AreNotEqual(originalName, editedStudent.Name);
        }

        [TestMethod]
        public void StudentDoCourse()
        {
            Repository<Student> repositoryStudent = new Repository<Student>(database);
            Repository<Course> repositoryCourse = new Repository<Course>(database);

            Course course = new Course("Mathematics");
            repositoryCourse.Save(course);

            Student student = new Student("Julius Prest");
            student.Courses.Add(course);
            repositoryStudent.Save(student);

            student.Courses.First().Id.Should().Be(course.Id);
        }

        [TestMethod]
        public void StudentEnrolls()
        {
            Repository<Student> repositoryStudent = new Repository<Student>(database);
            Repository<Enrollment> repositoryEnrollment = new Repository<Enrollment>(database);

            Student student = new Student("Julius Prest");
            repositoryStudent.Save(student);

            var ENROLLMENT_DATE = DateTime.Now;
            Enrollment enrollment = new Enrollment(student, ENROLLMENT_DATE);
            repositoryEnrollment.Save(enrollment);

            enrollment.Student.Id.Should().Be(student.Id);
            enrollment.Date.Should().Be(enrollment.Date);
        }

        [TestMethod , Ignore]
        public void StudentDeleteWithCourse()
        {
            Repository<Student> repositoryStudent = new Repository<Student>(database);
            Repository<Course> repositoryCourse = new Repository<Course>(database);

            Course course = new Course("Mathematics");
            repositoryCourse.Save(course);

            Student student = new Student("Julius Prest");
            student.Courses.Add(course);
            repositoryStudent.Save(student);

            repositoryStudent.Delete(student);

            Course confirmCourseStillExists = repositoryCourse.GetWhere(c => c.Id == course.Id).First();
            confirmCourseStillExists.Name.Should().Be("Mathematics");
        }

    }
}
