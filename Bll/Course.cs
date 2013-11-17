using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Course : Entity<Model.Course,Dal.EntityFramework.Course>
    {
        public List<Model.Course> FindLatest(int count)
        {
            Dal.Course dalCourse = new Dal.Course();
            return this.DalEntityListToModelEntityList(dalCourse.FindLatest(count));
        }

        protected override Model.Course DalEntityToModelEntity(Dal.EntityFramework.Course dalEntity)
        {
            return new Model.Course()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                Description = dalEntity.Description,
                Image = dalEntity.Image,
                TeacherId = dalEntity.TeacherId,
                Created = dalEntity.Created
            };
        }

        protected override Dal.EntityFramework.Course ModelEntityToDalEntity(Model.Course modelEntity)
        {
            return new Dal.EntityFramework.Course()
            {
                Id = modelEntity.Id,
                Name = modelEntity.Name,
                Description = modelEntity.Description,
                Image = modelEntity.Image,
                TeacherId = modelEntity.TeacherId,
                Created = modelEntity.Created
            };
        }
    }
}
