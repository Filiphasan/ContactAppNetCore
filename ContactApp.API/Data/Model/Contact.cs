using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Model
{
    public class Contact : BaseModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
