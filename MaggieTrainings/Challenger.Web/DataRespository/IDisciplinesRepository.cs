using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.Models;

namespace MaggieTrainings.Web.DataRespository
{
    public interface IDisciplinesRepository
    {
        void Add(TrainingDiscipline training);
        TrainingDiscipline Get(int id);
        IList<TrainingDiscipline> GetAll();
        void CleanRepository();
        void Remove(int id);
        void Update(TrainingDiscipline training);
    }
}