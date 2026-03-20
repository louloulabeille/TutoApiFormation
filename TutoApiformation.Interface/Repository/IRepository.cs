using System;
using System.Collections.Generic;
using System.Text;

namespace TutoApiformation.Interface.Repository
{
    public interface IRepository <T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id);
        public IEnumerable<T> Where(Func<T,bool> predicate);
        public T Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
