using ContactApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Interfaces
{
    public interface IContactService
    {
        Task<ContactGetModel> GetByIdAsync(string id);
        Task<IEnumerable<ContactGetModel>> GetAllAsync();
        Task<IEnumerable<ContactGetModel>> GetAllNonDeleteAsync();
        Task<ContactGetModel> AddAsync(ContactAddModel model);
        ContactGetModel Add(ContactAddModel model);
        Task<bool> DeleteAsync(string id);
        bool Delete(string id);
        Task<bool> SoftDeleteAsync(string id);
        bool SoftDelete(string id);
        Task<ContactGetModel> UpdateAsync(ContactUpdateModel model);
        ContactGetModel Update(ContactUpdateModel model);
    }
}
