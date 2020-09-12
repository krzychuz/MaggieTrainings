﻿using LiteDB;
using System;

namespace MaggieTrainings.Web.Models
{
    public class Training
    {
        public int Id { get; set; }

        public DateTime AddDate { get; set; }
        
        public DateTime EditDate { get; set; }

        public TrainingResult TrainingResult { get; set; }
    }
}
