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
    public class ExamTest
    {
        private DatabaseConnection database = new DatabaseConnection();

        [TestInitialize]
        public void Initialize()
        {
            Repository<Exam> examRepository = new Repository<Exam>(database);
            Repository<Student> studentRepository = new Repository<Student>(database);
            Repository<Course> courseRepository = new Repository<Course>(database);

            var examList = examRepository.GetAll();

            foreach (var exam in examList)
            {
                studentRepository.Delete(exam.Student);
                courseRepository.Delete(exam.Course);
                examRepository.Delete(exam);
            }
        }

        [TestMethod]
        public void CreateExam()
        {
            var studentRepository = new Repository<Student>(database);
            var courseRepository = new Repository<Course>(database);
            var examRepository = new Repository<Exam>(database);

            var student = new Student("Renan Basque");
            var course = new Course("Physics");

            studentRepository.Save(student);
            courseRepository.Save(course);

            var GRADE_SCORE = 7;
            var exam = new Exam(student, course, GRADE_SCORE);
            examRepository.Save(exam);
        }
    }
}
