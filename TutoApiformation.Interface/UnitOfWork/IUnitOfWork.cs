using System;
using System.Collections.Generic;
using System.Text;
using TutoApiformation.Interface.Repository;

namespace TutoApiformation.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<T>? Repository<T>() where T : class;
        public int SaveChanges();
    }
}
