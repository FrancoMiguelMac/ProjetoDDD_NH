using NHibernate;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        public readonly ISession _session = NHibernateHelper.OpenSession();
        
        public void Add(TEntity obj)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(obj);
                tran.Commit();
            }
        }

        public TEntity GetById(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(obj);
                tran.Commit();
            }
        }

        public void Remove(TEntity obj)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(obj);
                tran.Commit();
            }
        }

        public void Dispose()
        {

        }
    }
}
