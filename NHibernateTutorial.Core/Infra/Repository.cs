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
        private IUnityOfWork unityOfWork;

        public Repository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public T Save(T model)
        {
            this.unityOfWork.GetSession().Save(model);
            return model;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return this.unityOfWork.GetSession().Query<T>()
                .Where(predicate)
                .Select(model => model);
        }

        public IQueryable<T> GetAll()
        {
            return this.unityOfWork.GetSession().Query<T>()
                .Select(model => model);
        }

        public void Delete(T model)
        {
            this.unityOfWork.GetSession().Delete(model);
        }
    }
}
