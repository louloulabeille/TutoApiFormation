using System;
using System.Collections.Generic;
using System.Text;
using TutoApiformation.Infrastructure.Database;
using TutoApiformation.Infrastructure.Repository;
using TutoApiformation.Interface.Repository;
using TutoApiformation.Interface.UnitOfWork;

namespace TutoApiformation.Infrastructure
{
    public class UnitOfWork(TutoApiDbContext context) : IUnitOfWork
    {
        #region private properties
        private readonly TutoApiDbContext _context = context;
        private readonly Dictionary<Type,object> _repository = [];
        private bool _disposed = false;
        #endregion


        #region implementation methode IUnitOfWork
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Retourne le bon repository selon la classe passée en générique
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IRepository<T>? Repository<T>() where T : class
        {
            var typeName = typeof(T);
            if (_repository.ContainsKey(typeName))
            {
                //return (IRepository<T>)_repository[typeName];
                return _repository[typeName] as IRepository<T>;
            }

            var repository = new Repository<T>(_context);
            _repository.Add(typeName, repository);

            return repository;
            
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        #endregion

        #region methode protected
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        #endregion 
    }
}
