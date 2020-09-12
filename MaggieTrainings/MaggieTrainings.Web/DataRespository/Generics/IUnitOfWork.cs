using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.DataRespository.Generics
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class, new();
        void Save();
    }
}
