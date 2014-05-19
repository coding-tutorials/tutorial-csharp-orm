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
        void Begin();
        void Commit();
        void Rollback();
    }

    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private ISession session;

        public UnityOfWork()
        {
            session = DatabaseConnection.GetSession();
            session.BeginTransaction();
        }

        public ISession GetSession()
        {
            return this.session;
        }

        public void Begin()
        {
            session.Transaction.Begin();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
        }

        public void Commit()
        {
            session.Transaction.Commit();

        }

        public void Dispose()
        {
            
        }
    }
}
