using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Linq;
using FluentNHibernate.Automapping;

namespace NHibernateTutorial.Core.Infra
{
    public class Repository<T> : ORMTutorial.Infra.IRepository<T>
    {
        private IUnityOfWork unitOfWork;

        public Repository(IUnityOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return this.unitOfWork.GetSession().Query<T>()
                .Where(predicate)
                .Select(model => model);
        }

        public IEnumerable<T> GetAll()
        {
            return this.unitOfWork.GetSession().Query<T>()
                .Select(model => model);
        }

        public T Save(T model, bool commit = true)
        {
            return this.Save(new List<T>(){model}, commit).First();
        }

        public IEnumerable<T> Save(IEnumerable<T> modelList, bool commit = true)
        {
            foreach(var model in modelList)
                this.unitOfWork.GetSession().Save(model);
            if (commit) this.unitOfWork.Commit();
            return modelList;
        }

        public void Delete(T model, bool commit = true)
        {
            this.Delete(new List<T>() { model }, commit);
        }

        public void Delete(IEnumerable<T> modelList, bool commit = true)
        {
            //if (commit) this.unityOfWork.Begin();
            foreach(var model in modelList)
                this.unitOfWork.GetSession().Delete(model);
            if (commit) this.unitOfWork.Commit();
        }
    }
}
