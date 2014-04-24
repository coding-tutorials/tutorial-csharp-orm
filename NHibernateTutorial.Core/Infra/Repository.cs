using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Linq;
using FluentNHibernate.Automapping;

namespace NHibernateTutorial.Core.Infra
{
    public class Repository<T>
    {
        private readonly ISessionFactory SessionFactory;
        private readonly ISession Session;

        public Repository()
        {
            var NHConfigure = new NHibernate.Cfg.Configuration()
                .Configure("hibernate.cfg.xml");

            this.SessionFactory = FluentNHibernate.Cfg.Fluently.Configure(NHConfigure)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model.Student>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Model.Course>())
                .BuildSessionFactory();

            //if (SessionFactory.IsClosed)
                this.Session = this.SessionFactory.OpenSession();
            //else
            //    this.Session = this.SessionFactory.GetCurrentSession();
        }

        public T Save(T model)
        {
            this.Session.BeginTransaction();
            this.Session.Save(model);
            this.Session.Transaction.Commit();
            return model;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return this.Session.Query<T>()
                .Where(predicate)
                .Select(model => model);
        }

        public IQueryable<T> GetAll()
        {
            return this.Session.Query<T>()
                .Select(model => model);
        }

        public void Delete(T model)
        {
            this.Session.BeginTransaction();
            this.Session.Delete(model);
            this.Session.Transaction.Commit();
        }
    }
}
