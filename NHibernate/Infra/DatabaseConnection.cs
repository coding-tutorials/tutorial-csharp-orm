using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

namespace NHibernateTutorial.Core.Infra
{
    public class DatabaseConnection
    {
        private static ISession session;

        public static ISession GetSession()
        {
            if(session == null){
                var nHConfigure = new NHibernate.Cfg.Configuration()
                                        .Configure("hibernate.cfg.xml");

                var sessionFactory = FluentNHibernate.Cfg.Fluently.Configure(nHConfigure)
                                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model.Student>())
                                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model.Course>())
                                    .BuildSessionFactory();

               session = sessionFactory.OpenSession();
            }

            return session;
        }
    }
}
