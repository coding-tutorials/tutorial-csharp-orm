using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Student : IRepository<Dal.EntityFramework.Student>
    {
        private Dal.EntityFramework.HighSchoolMVCEntities DbContext = new EntityFramework.HighSchoolMVCEntities();





        public Dal.EntityFramework.Student Find(int id)
        {
            return (from student in this.DbContext.Student 
                   where student.Id.Equals(id)
                    select student).SingleOrDefault();
        }

        public List<Dal.EntityFramework.Student> Find(Dal.EntityFramework.Student model)
        {
            throw new NotImplementedException();
        }

        public int Save(Dal.EntityFramework.Student item)
        {
            throw new NotImplementedException();

            if (item.Id > 0)
            {

            }
            else
            {

            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
