using ContactApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Interfaces
{
    public interface IContactInfoService
    {
        Task<ContactInfoGetModel> GetByIdAsync(int id);
        Task<IEnumerable<ContactInfoGetModel>> GetUserContactInfoAsync(string userId);
        Task<IEnumerable<ContactInfoGetModel>> GetAllAsync();
        Task<IEnumerable<ContactInfoGetModel>> GetAllNonDeleteAsync();
        Task<ContactInfoGetModel> AddAsync(ContactInfoAddModel model);
        ContactInfoGetModel Add(ContactInfoAddModel model);
        Task<bool> DeleteAsync(int id);
        bool Delete(int id);
        Task<bool> SoftDeleteAsync(int id);
        bool SoftDelete(int id);
        Task<ContactInfoGetModel> UpdateAsync(ContactInfoUpdateModel model);
        ContactInfoGetModel Update(ContactInfoUpdateModel model);
    }
}
