using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class User
    {
        [Test]
        public void Database()
        {
            Repository.User repositoryUser = new Repository.User();

            //Insert a new user
            Model.User user1 = new Model.User()
            {
                Login = "Test-User",
                Password = Bll.Util.EncodeMD5("TestPassword"),
            };

            user1.Id = repositoryUser.Save(user1);

            Assert.Greater(user1.Id, 0);

            //Update user
            String NewUserLogin = "Test-User-" + DateTime.Now.Ticks.ToString();
            Model.User user2 = new Model.User()
            {
                Id = user1.Id,
                Login = NewUserLogin
            };

            repositoryUser.Save(user2);

            //Login user
            Model.User user3 = repositoryUser.Get(NewUserLogin, Bll.Util.EncodeMD5("TestPassword"));

            Assert.AreNotEqual(user3, null);
            Assert.AreEqual(user3.Login, NewUserLogin);
        }
    }
}
