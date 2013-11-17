using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Student : Entity<Model.Student, Dal.EntityFramework.Student>
    {

        public int Save(Model.Student student)
        {
            throw new NotImplementedException();
        }

        public Model.Student Get(int Id)
        {
            throw new NotImplementedException();                             
        }

        public Model.Student GetByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Model.Student Login(String email, String password)
        {
            throw new NotImplementedException();
        }

        protected override Model.Student DalEntityToModelEntity(Dal.EntityFramework.Student dalEntity)
        {
            Model.Student model = new Model.Student();
            model.Id = dalEntity.Id;
            model.Name = dalEntity.Name;
            model.Name = dalEntity.Name;
            model.Image = dalEntity.Image;

            return model;
        }

        protected override Dal.EntityFramework.Student ModelEntityToDalEntity(Model.Student modelEntity)
        {
            Dal.EntityFramework.Student dalModel = new Dal.EntityFramework.Student();
            dalModel.Id = modelEntity.Id;
            dalModel.Name = modelEntity.Name;
            dalModel.Name = modelEntity.Name;
            dalModel.Image = modelEntity.Image;

            return dalModel;
        }
    }
}
