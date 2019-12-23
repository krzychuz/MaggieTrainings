using MaggieTrainings.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.DataRespository
{
    public interface ITrainingRepository
    {
        Task Add(Training training);
        Task<Training> Get(int id);
        Task<IList<Training>> GetAll();
        Task CleanRepository();
        Task Remove(Training training);
        Task Update(Training training);
    }
}