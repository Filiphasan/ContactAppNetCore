using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Model
{
    public class ReportGetModel
    {
        public string Location { get; set; }
        public int LocationCount { get; set; }
        public int ContactCountInLocation { get; set; }
        public int NumberCountInLocation { get; set; }
    }
}
