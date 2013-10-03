using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Course
    {
        
        private Dal.EntityFramework.HighSchoolMVCEntities DatabaseContext = new EntityFramework.HighSchoolMVCEntities();

        /// <summary>
        /// Get a single Course
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns>Course object</returns>
        public Dal.EntityFramework.Course Get(int id)
        {
            return this.DatabaseContext.Course.Where(i => i.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get a list of Courses
        /// </summary>
        /// <param name="skip">Pagination skip</param>
        /// <param name="count">Pagination count</param>
        /// <returns>List of Course</returns>
        public List<Dal.EntityFramework.Course> Get(int skip, int count)
        {
            return this.DatabaseContext.Course.OrderBy(i => i.Created).Skip(skip).Take(count).ToList();
        }

        public int Save(Dal.EntityFramework.Course course)
        {
            this.DatabaseContext.Course.Add(course);
        }

 
         
    }
}
