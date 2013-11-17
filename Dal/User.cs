using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class User
    {
       
        /*
        public Dal.EntityFramework.User Get(int id)
        {
            Dal.EntityFramework.HighSchoolMVCEntities DatabaseContext = new EntityFramework.HighSchoolMVCEntities();
            Dal.EntityFramework.User user = DatabaseContext.User.AsNoTracking().Where(i => i.Id == id).SingleOrDefault();

            return user;
        }

        public Dal.EntityFramework.User Get(String login, String password)
        {
            Dal.EntityFramework.HighSchoolMVCEntities DatabaseContext = new EntityFramework.HighSchoolMVCEntities();
            Dal.EntityFramework.User user = DatabaseContext.User.AsNoTracking().Where(i => i.Login == login && i.Password == Bll.Util.EncodeMD5(password)).SingleOrDefault();

            return user;
        }

        public int Save(Dal.EntityFramework.User user)
        {
            Dal.EntityFramework.HighSchoolMVCEntities DatabaseContext = new EntityFramework.HighSchoolMVCEntities();

            if (user.Id > 0)
            {
                
                Dal.EntityFramework.User dalUser = this.Get(user.Id);

                if (!String.IsNullOrEmpty(user.Login))
                    dalUser.Login = user.Login;
                if (!String.IsNullOrEmpty(user.Image))
                    dalUser.Image = user.Image;
              
                DatabaseContext.User.Attach(user);
                DatabaseContext.Entry(user).Property(i => i.Login).IsModified = true;
            }
            else
            {
                user.Created = DateTime.Now;
                DatabaseContext.User.Add(user);
            }

            try
            {

                DatabaseContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException  e)
            {

            }
            return user.Id;
        }*/
    }
}
