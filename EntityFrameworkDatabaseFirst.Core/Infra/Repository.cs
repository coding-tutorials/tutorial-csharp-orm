using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Data.Entity;

namespace EntityFrameworkDatabaseFirst.Core.Infra
{
    public class Repository<T> where T : class
    {
        private DbContext Session;

        public Repository(DbContext context)
        {
            Session = context;
        }

        public T Save(T model)
        {
            Session.Set<T>().Add(model);
            Session.SaveChanges();
            return model;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Session.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Session.Set<T>();
        }

        public void Delete(T model)
        {
            Session.Set<T>().Remove(model);
            Session.SaveChanges();
        }
    }
}
