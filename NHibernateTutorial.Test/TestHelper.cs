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
        protected DatabaseConnection database = new DatabaseConnection();

        protected Course CreateGenericCourse()
        {
            Course course = null;

            using (var unityOfWork = new UnityOfWork())
            {
                Repository<Course> courseRepository = new Repository<Course>(unityOfWork);
                course = new Course("Test Course");
                unityOfWork.Begin();
                courseRepository.Save(course);
                unityOfWork.Commit();
            }

            return course;
        }

        protected Student CreateGenericStudent()
        {
            Student student = null;

            using (var unityOfWork = new UnityOfWork())
            {
                Repository<Student> courseRepository = new Repository<Student>(unityOfWork);
                student = new Student("Test Student");
                courseRepository.Save(student);
                unityOfWork.Commit();
            }

            return student;
        }

    }
}
