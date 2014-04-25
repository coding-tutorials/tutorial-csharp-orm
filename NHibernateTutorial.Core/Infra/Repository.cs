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
        private ISession Session;

        public Repository(DatabaseConnection databaseConnection)
        {
            Session = databaseConnection.Session;
        }

        public Repository()
        {
        }

        public T Save(T model)
        {
            Session.BeginTransaction();
            Session.Save(model);
            Session.Transaction.Commit();
            return model;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>()
                .Where(predicate)
                .Select(model => model);
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>()
                .Select(model => model);
        }

        public void Delete(T model)
        {
            Session.BeginTransaction();
            Session.Delete(model);
            Session.Transaction.Commit();
        }
    }
}
