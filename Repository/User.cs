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
            return null; // this.DalToModel(DalUser.Get(id));
        }

        public Model.User Get(String login, String password)
        {
            return null; // this.DalToModel(DalUser.Get(login, password));
        }

        public int Save(Model.User user)
        {
            return 0; // this.DalUser.Save(this.ModelToDal(user));
        }

        private Model.User DalToModel(Dal.EntityFramework.User dalModel)
        {
            return new Model.User()
            {
                Id = dalModel.Id,
                Email = dalModel.Email,
                Password = dalModel.Password,
                Created = dalModel.Created
            };
        }

        private Dal.EntityFramework.User ModelToDal(Model.User model)
        {
            return new Dal.EntityFramework.User()
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                Created = model.Created
            };
        }
    }
}
