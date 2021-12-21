using ContactApp.API.Data.Model;
using ContactApp.API.Helpers;
using ContactApp.API.Interfaces;
using ContactApp.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IRedisService _redisService;
        private readonly ContactInfoCacheKeys _contactInfoCacheKeys;

        public ContactInfoService(IContactInfoRepository contactInfoRepository, IRedisService redisService, IOptions<ContactInfoCacheKeys> options)
        {
            _contactInfoRepository = contactInfoRepository;
            _redisService = redisService;
            _contactInfoCacheKeys = options.Value;
        }

        public ContactInfoGetModel Add(ContactInfoAddModel model)
        {
            try
            {
                var newEntity = new ContactInfo
                {
                    Key = model.Key,
                    Value = model.Value,
                    ContactId = model.ContactId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                var data = _contactInfoRepository.InsertReturn(newEntity);
                var contactInfoGetModel = new ContactInfoGetModel
                {
                    Id = data.Id,
                    Key = data.Key,
                    Value = data.Value,
                    ContactId = data.ContactId
                };
                #region Redis Cache
                _redisService.Set<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, data.Id), contactInfoGetModel);
                #endregion
                return contactInfoGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactInfoGetModel> AddAsync(ContactInfoAddModel model)
        {
            try
            {
                var newEntity = new ContactInfo
                {
                    Key = model.Key,
                    Value = model.Value,
                    ContactId = model.ContactId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                var data = await _contactInfoRepository.InsertAsyncReturn(newEntity);
                var contactInfoGetModel = new ContactInfoGetModel
                {
                    Id = data.Id,
                    Key = data.Key,
                    Value = data.Value,
                    ContactId = data.ContactId
                };
                #region Redis Cache
                _redisService.Set<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, data.Id), contactInfoGetModel);
                #endregion
                return contactInfoGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _contactInfoRepository.GetById(id);
                if (entity == null) return false;
                _contactInfoRepository.Delete(entity);
                #region Redis Cache
                _redisService.Remove(string.Format(_contactInfoCacheKeys.OneContactInfo, id));
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _contactInfoRepository.GetByIdAsync(id);
                if (entity == null) return false;
                _contactInfoRepository.Delete(entity);
                #region Redis Cache
                _redisService.Remove(string.Format(_contactInfoCacheKeys.OneContactInfo, id));
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<ContactInfoGetModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactInfoGetModel>> GetAllNonDeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ContactInfoGetModel> GetByIdAsync(int id)
        {
            try
            {
                var data = _redisService.Get<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, id));
                if (data != null) return data;
                var entity = await _contactInfoRepository.GetByIdAsync(id);
                var contactInfoGetModel = new ContactInfoGetModel
                {
                    Id = entity.Id,
                    Key = entity.Key,
                    Value = entity.Value,
                    ContactId = entity.ContactId
                };
                #region Redis Cache
                _redisService.Set<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, id), contactInfoGetModel);
                #endregion
                return contactInfoGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContactInfoGetModel>> GetUserContactInfoAsync(string userId)
        {
            try
            {
                var datas = _redisService.Get<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, userId));
                if (datas != null) return datas;
                var entities = await _contactInfoRepository.Where(x => x.IsDeleted == false && x.ContactId == userId).ToListAsync();
                var list = entities.Select(x => new ContactInfoGetModel
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                    ContactId = x.ContactId
                });
                #region Redis Cache
                _redisService.Set<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, userId), list);
                #endregion
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SoftDelete(int id)
        {
            try
            {
                var entity = _contactInfoRepository.GetById(id);
                if (entity == null) return false;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                _contactInfoRepository.Update(entity);
                #region Redis Cache
                _redisService.Get<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, id));
                var cacheDatas = _redisService.Get<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, entity.ContactId));
                if (cacheDatas != null && cacheDatas.Any())
                {
                    var newCacheDatas = cacheDatas.Where(x => x.Id != id).ToList();
                    _redisService.Set<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, entity.ContactId), newCacheDatas);
                }
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var entity = await _contactInfoRepository.GetByIdAsync(id);
                if (entity == null) return false;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                _contactInfoRepository.Update(entity);
                #region Redis Cache
                _redisService.Get<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, id));
                var cacheDatas = _redisService.Get<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, entity.ContactId));
                if (cacheDatas != null && cacheDatas.Any())
                {
                    var newCacheDatas = cacheDatas.Where(x => x.Id != id).ToList();
                    _redisService.Set<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, entity.ContactId), newCacheDatas);
                }
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ContactInfoGetModel Update(ContactInfoUpdateModel model)
        {
            try
            {
                var entity = _contactInfoRepository.GetById(model.Id);
                if (entity == null) throw new Exception("Not Found!");
                entity.Key = model.Key;
                entity.Value = model.Value;
                entity.UpdatedAt = DateTime.UtcNow;
                _contactInfoRepository.Update(entity);
                var contactInfoGetModel = new ContactInfoGetModel
                {
                    Id = entity.Id,
                    Key = entity.Key,
                    Value = entity.Value,
                    ContactId = entity.ContactId
                };
                #region Redis Cache
                _redisService.Set<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, entity.Id), contactInfoGetModel);
                var userInfos = _contactInfoRepository.Where(x => x.IsDeleted == false && x.ContactId == entity.ContactId).ToList();
                var list = userInfos.Select(x => new ContactInfoGetModel
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                    ContactId = x.ContactId
                });
                _redisService.Set<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, entity.ContactId), list);
                #endregion
                return contactInfoGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactInfoGetModel> UpdateAsync(ContactInfoUpdateModel model)
        {
            try
            {
                var entity = await _contactInfoRepository.GetByIdAsync(model.Id);
                if (entity == null) throw new Exception("Not Found!");
                entity.Key = model.Key;
                entity.Value = model.Value;
                entity.UpdatedAt = DateTime.UtcNow;
                _contactInfoRepository.Update(entity);
                var contactInfoGetModel = new ContactInfoGetModel
                {
                    Id = entity.Id,
                    Key = entity.Key,
                    Value = entity.Value,
                    ContactId = entity.ContactId
                };
                #region Redis Cache
                _redisService.Set<ContactInfoGetModel>(string.Format(_contactInfoCacheKeys.OneContactInfo, entity.Id), contactInfoGetModel);
                var userInfos = await _contactInfoRepository.Where(x => x.IsDeleted == false && x.ContactId == entity.ContactId).ToListAsync();
                var list = userInfos.Select(x => new ContactInfoGetModel
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                    ContactId = x.ContactId
                });
                _redisService.Set<IEnumerable<ContactInfoGetModel>>(string.Format(_contactInfoCacheKeys.MultiContactInfo, entity.ContactId), list);
                #endregion
                return contactInfoGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
