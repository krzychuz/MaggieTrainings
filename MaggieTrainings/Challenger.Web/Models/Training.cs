using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.Models
{
    public class Training
    {
        [BsonId]
        public int Id { get; set; }

        [BsonField]
        public string AddDate { get; set; }
        
        [BsonField]
        public string EditDate { get; set; }
    }
}
