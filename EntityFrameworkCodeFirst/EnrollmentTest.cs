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
    public class EnrollmentTest
    {
        private DatabaseConnection database = new DatabaseConnection();

        [TestInitialize]
        public void Initialize()
        {
            Repository<Student> studentRepository = new Repository<Student>(database);
            Repository<Enrollment> enrollmentRepository = new Repository<Enrollment>(database);
            var enrollmentList = enrollmentRepository.GetAll();

            foreach (var enrollment in enrollmentList.ToList())
            {
                if (enrollment.Student != null)
                    studentRepository.Delete(enrollment.Student);

                enrollmentRepository.Delete(enrollment);
            }
        }

        [TestCleanup]
        public void Dispose()
        {
            this.database.Dispose();
        }

        [TestMethod]
        public void EnrollementCreate()
        {
            var studentRepository = new Repository<Student>(database);
            var enrollmentRepository = new Repository<Enrollment>(database);

            var student = new Student("Renan Basque");
            studentRepository.Save(student);

            var ENROLLMENT_DATE = DateTime.Now;
            var enrollment = new Enrollment(student, ENROLLMENT_DATE);
            enrollmentRepository.Save(enrollment);
        }

        [TestMethod]
        public void EnrollementEdit()
        {
            var studentRepository = new Repository<Student>(database);
            var enrollmentRepository = new Repository<Enrollment>(database);

            var student = new Student("Renan Basque");
            studentRepository.Save(student);

            var ENROLLMENT_DATE = DateTime.Now;
            var enrollment = new Enrollment(student, ENROLLMENT_DATE);
            enrollmentRepository.Save(enrollment);

            var editEnrollment = enrollmentRepository.GetWhere(e => e.Id == enrollment.Id).First();
            editEnrollment.Date = DateTime.Now.AddDays(1);
            enrollmentRepository.Save(editEnrollment);

            var confirmEditedEnrollment = enrollmentRepository.GetWhere(e => e.Id == enrollment.Id).First();
            confirmEditedEnrollment.Date.Should().NotBe(ENROLLMENT_DATE);
        }

        [TestMethod]
        public void EnrollementDeleteWithStudent()
        {
            var studentRepository = new Repository<Student>(database);
            var enrollmentRepository = new Repository<Enrollment>(database);

            
            var student = new Student("Renan Basque");
            studentRepository.Save(student);
            int studentId = student.Id;

            var ENROLLMENT_DATE = DateTime.Now;
            var enrollment = new Enrollment(student, ENROLLMENT_DATE);
            enrollmentRepository.Save(enrollment);

            enrollmentRepository.Delete(enrollment);

            var confirmStudentStillExist = studentRepository.GetWhere(s => s.Id == studentId).First();
            confirmStudentStillExist.Id.Should().Be(student.Id);
        }


    }
}
