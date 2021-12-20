using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Model
{
    public class CustomConnectionStringOptions
    {
        public string SqlServer { get; set; }
        public string Redis { get; set; }
    }
}
