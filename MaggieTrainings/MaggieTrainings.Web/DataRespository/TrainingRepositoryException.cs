using System;

namespace MaggieTrainings.Web.DataRespository
{
    public class TrainingRepositoryException : Exception
    {
        public TrainingRepositoryException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
