using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORMTutorial.Infra
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T Save(T model, bool commit = true);
        IEnumerable<T> Save(IEnumerable<T> modelList, bool commit = true);
        void Delete(T model, bool commit = true);
        void Delete(IEnumerable<T> modelList, bool commit = true);
    }
}
