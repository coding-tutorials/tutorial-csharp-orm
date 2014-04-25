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
        private DatabaseConnection database = new DatabaseConnection();

        [TestInitialize]
        public void Initialize()
        {
            Repository<Student> studentRepository = new Repository<Student>(database);

            var studentList = studentRepository.GetAll().ToList();

            foreach(var student in studentList)
                studentRepository.Delete(student);
        }

        [TestMethod]
        public void CreateStudent()
        {
            Student  student = new Student("Julius Prest");
            Repository<Student> repositoryStudent = new Repository<Student>(database);
            repositoryStudent.Save(student);

            Assert.AreNotEqual(0, student.Id);
        }

        [TestMethod]
        public void EditStudent()
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
        public void CreateStudentWithCourse()
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
        public void CreateStudentWithExam()
        {
            Repository<Student> repositoryStudent = new Repository<Student>(database);
            Repository<Course> repositoryCourse = new Repository<Course>(database);
            Repository<Exam> repositoryExam = new Repository<Exam>(database);

            Course course = new Course("Mathematics");
            repositoryCourse.Save(course);

            Student student = new Student("Julius Prest");
            student.Courses.Add(course);
            repositoryStudent.Save(student);

            Exam exam = new Exam(student, course, 7);
            repositoryExam.Save(exam);

            exam.Course.Id.Should().Be(course.Id);
            exam.Student.Id.Should().Be(student.Id);
            exam.Score.Should().Be(exam.Score);
        }

        [TestMethod]
        public void DeleteStudentWithCourse()
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
