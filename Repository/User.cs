using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class User
    {
        private Dal.User DalUser = new Dal.User();

        public Model.User Get(int id)
        {
            return this.DalToModel(DalUser.Get(id));
        }

        public Model.User Get(String login, String password)
        {
            return this.DalToModel(DalUser.Get(login, password));
        }

        public int Save(Model.User user)
        {
            return this.DalUser.Save(this.ModelToDal(user));
        }

        private Model.User DalToModel(Dal.EntityFramework.User dalModel)
        {
            return new Model.User()
            {
                Id = dalModel.Id,
                Login = dalModel.Login,
                Password = dalModel.Password,
                Image = dalModel.Image,
                Created = dalModel.Created
            };
        }

        private Dal.EntityFramework.User ModelToDal(Model.User model)
        {
            return new Dal.EntityFramework.User()
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                Image = model.Image,
                Created = model.Created
            };
        }
    }
}
