using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.Models;

namespace MaggieTrainings.Web.DataRespository
{
    public interface IDisciplinesRepository
    {
        IList<TrainingDiscipline> GetDisciplines();
    }
}