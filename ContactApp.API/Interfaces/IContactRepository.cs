using ContactApp.API.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Interfaces
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
    }
}
