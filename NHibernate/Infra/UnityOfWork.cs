using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

namespace NHibernateTutorial.Core.Infra
{
    public interface IUnityOfWork
    {
        ISession GetSession();
        void Commit();
        void Rollback();
    }
}
