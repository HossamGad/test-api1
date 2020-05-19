using SFF.Datasource.Model;
using System.Collections.Generic;

namespace SFF.Datasource.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> List { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T FindById(int id);
    }
}