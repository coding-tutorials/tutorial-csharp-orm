using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

namespace NHibernateTutorial.Core.Infra
{
    public class DatabaseConnection : IDisposable
    {
        private readonly ISessionFactory SessionFactory;
        public ISession Session { get; private set; }

        public DatabaseConnection()
        {
            var NHConfigure = new NHibernate.Cfg.Configuration()
                .Configure("hibernate.cfg.xml");

            this.SessionFactory = FluentNHibernate.Cfg.Fluently.Configure(NHConfigure)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model.Student>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model.Course>())
                .BuildSessionFactory();

            this.Session = this.SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
