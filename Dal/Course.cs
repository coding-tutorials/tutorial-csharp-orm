using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Course : IRepository<Dal.EntityFramework.Course>
    {
        private Dal.EntityFramework.HighSchoolMVCEntities DbContext = new EntityFramework.HighSchoolMVCEntities();



        public EntityFramework.Course Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityFramework.Course> FindLatest(int count)
        {
            return (from courses in this.DbContext.Course
                    where courses.Deleted == null
                    orderby courses.Created ascending
                    select courses).Take(count).ToList();

        }

        public int Save(EntityFramework.Course item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }


        public List<EntityFramework.Course> Find(EntityFramework.Course item)
        {
            throw new NotImplementedException();
        }
    }
}
