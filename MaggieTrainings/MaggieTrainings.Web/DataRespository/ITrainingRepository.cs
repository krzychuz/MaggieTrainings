using MaggieTrainings.Domain.Models.Data;
using System.Collections.Generic;

namespace MaggieTrainings.Web.DataRespository
{
    public interface ITrainingRepository
    {
        void Add(Training training);
        Training Get(int id);
        IList<Training> GetAll();
        void CleanRepository();
        void Remove(Training training);
        void Update(Training training);
    }
}