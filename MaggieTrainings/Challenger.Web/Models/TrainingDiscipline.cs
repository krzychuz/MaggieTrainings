using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.Models
{
    public enum TrainingDiscipline
    {
        [Description("Nie zdefiniowano")]
        Undefined,
        [Description("Jazda na rowerze")]
        Cycling,
        [Description("Chodzenie")]
        Walking,
        [Description("Bieganie")]
        Running,
        [Description("Pływanie")]
        Swimming
    }
}
