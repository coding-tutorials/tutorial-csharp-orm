using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IRepository<T>
    {
        T Find(int id);
        List<T> Find(T item);
        int Save(T item);
        void Remove(int id);
    }
}
