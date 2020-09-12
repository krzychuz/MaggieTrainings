using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.Extensions
{
    public static class MapperConfigurationExtensions
    {
        public static void AddTrainingProfile(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<TrainingProfile>();
        }
    }
}
