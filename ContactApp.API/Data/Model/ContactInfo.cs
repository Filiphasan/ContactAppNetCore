using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Model
{
    public class ContactInfo : BaseModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Information Type, One Of "Telefon Numarası, E-Mail Adresi, Konum"
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Information Type Content
        /// </summary>
        public string Value { get; set; }
        public string ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
