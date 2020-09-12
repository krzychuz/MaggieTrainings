using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MaggieTrainings.Web.DataRespository.Generics
{
    public interface IGenericRepository<T>
    {
        T GetById(object id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetAll();

        void Edit(T entity);

        void Insert(T entity);

        void Delete(object id);

        void DeleteAll();

        int Count();
    }
}