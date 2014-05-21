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
    public class CourseTest : TestHelper
    {
        [TestInitialize]
        public void Initialize()
        {
            Repository<Course> courseRepository = new Repository<Course>(new UnityOfWork());
            var courseList = courseRepository.GetAll();
            courseRepository.Delete(courseList);
        }

        [TestMethod]
        public void CourseCreate()
        {
            Course course = this.CreateGenericCourse();
            Assert.AreNotEqual(0, course.Id);
        }

        [TestMethod]
        public void CourseEdit()
        {
            
            var course = this.CreateGenericCourse();

            Repository<Course> courseRepository = new Repository<Course>(new UnityOfWork());
            var courseEdit = courseRepository.GetWhere(c => c.Id == course.Id).First();
            courseEdit.Name = "Physics";
            courseRepository.Save(courseEdit);

            var checkEditedCourse = courseRepository.GetWhere(c => c.Id == courseEdit.Id).First();
            checkEditedCourse.Should().NotBe(course.Name);
        }

  
        [TestMethod]
        public void CourseAddStudent()
        {
            Course course;
            Student student;

            using (var unityOfWork = new UnityOfWork())
            {
                Repository<Course> courseRepository = new Repository<Course>(unityOfWork);
                Repository<Student> studentRepository = new Repository<Student>(unityOfWork);

                student = new Student("Newbie student");
                //student.Courses.Add(course);
                studentRepository.Save(student, false);

                unityOfWork.Commit();
            }

            using (var unityOfWork = new UnityOfWork())
            {
                Repository<Course> courseRepository = new Repository<Course>(unityOfWork);
                Repository<Student> studentRepository = new Repository<Student>(unityOfWork);

                course = new Course("French");
                course.Students.Add(student);
                courseRepository.Save(course, false);

                unityOfWork.Commit();
            }

            Repository<Student> studentRepository2 = new Repository<Student>(new UnityOfWork());
            var searchStudent = studentRepository2.GetWhere(x => x.Id == student.Id).First();
            searchStudent.Courses.First().Id.Should().Be(course.Id);
        }

        [TestMethod]
        public void CourseDeleteWithStudent()
        {
            using (var unityOfWork = new UnityOfWork())
            {
                Repository<Course> courseRepository = new Repository<Course>(unityOfWork);
                Repository<Student> studentRepository = new Repository<Student>(unityOfWork);

                var student = new Student("Newbie student");
                studentRepository.Save(student);
                int studentId = student.Id;

                var course = new Course("French");
                course.Students.Add(student);

                courseRepository.Save(course);
    
                courseRepository.Delete(course);
                unityOfWork.Commit();

                var checkStudentStillExists = studentRepository.GetWhere(s => s.Id == studentId).First();

                checkStudentStillExists.Name.Should().Be(student.Name);
            }
        }

        [TestCleanup]
        public void Dispose()
        {
            //this.database.Dispose();
        }
    }
}
