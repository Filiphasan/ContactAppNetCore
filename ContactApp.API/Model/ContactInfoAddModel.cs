using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Model
{
    public class ContactInfoAddModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string ContactId { get; set; }
    }
}
