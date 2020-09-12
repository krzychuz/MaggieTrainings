using AutoMapper;
using MaggieTrainings.Domain.Models.Data;
using MaggieTrainings.Domain.Models.Requests;
using MaggieTrainings.Domain.Models.Responses;

namespace MaggieTrainings.Web.Extensions
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            // Request -> Data
            CreateMap<TrainingRequest, Training>();
            CreateMap<TrainingDisciplineRequest, TrainingDiscipline>();
            CreateMap<TrainingResultRequest, TrainingResult>();

            // Data -> Response
            CreateMap<Training, TrainingResponse>();
            CreateMap<TrainingDiscipline, TrainingDisciplineResponse>();
            CreateMap<TrainingResult, TrainingResultResponse>();

            // Dashboard
            CreateMap<DashboardData, DashboardDataResponse>();
        }
    }
}