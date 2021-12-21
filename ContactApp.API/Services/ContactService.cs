using ContactApp.API.Data.Model;
using ContactApp.API.Helpers;
using ContactApp.API.Interfaces;
using ContactApp.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IRedisService _redisService;
        private readonly ContactCacheKeys _contactCacheKeys;
        private readonly ContactCacheStringHelpers _contactCacheStringHelpers;

        public ContactService(IContactRepository contactRepository, IRedisService redisService, IOptions<ContactCacheKeys> contactCacheKeysOptions, IOptions<ContactCacheStringHelpers> contactCacheStrHelperOptions)
        {
            _contactRepository = contactRepository;
            _redisService = redisService;
            _contactCacheKeys = contactCacheKeysOptions.Value;
            _contactCacheStringHelpers = contactCacheStrHelperOptions.Value;
        }

        public ContactGetModel Add(ContactAddModel model)
        {
            try
            {
                var newEntity = new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Firm = model.Firm,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                var data = _contactRepository.InsertReturn(newEntity);
                var contactGetModel = new ContactGetModel
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Firm = data.Firm
                };
                #region Redis Cache
                _redisService.Set<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, data.Id), contactGetModel);
                var cacheAllDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll));
                if (cacheAllDatas != null && cacheAllDatas.Any())
                {
                    var newCacheAllDatas = cacheAllDatas.ToList();
                    newCacheAllDatas.Add(contactGetModel);
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact,_contactCacheStringHelpers.FilterAll), newCacheAllDatas);
                }
                var cacheAllNonDeleteDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete));
                if (cacheAllNonDeleteDatas != null && cacheAllNonDeleteDatas.Any())
                {
                    var newCacheAllNonDeleteDatas = cacheAllNonDeleteDatas.ToList();
                    newCacheAllNonDeleteDatas.Add(contactGetModel);
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), newCacheAllNonDeleteDatas);
                }
                #endregion
                return contactGetModel;
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public async Task<ContactGetModel> AddAsync(ContactAddModel model)
        {
            try
            {
                var newEntity = new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Firm = model.Firm,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                var data = await _contactRepository.InsertAsyncReturn(newEntity);
                var contactGetModel = new ContactGetModel
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Firm = data.Firm
                };
                #region Redis Cache
                _redisService.Set<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, data.Id), contactGetModel);
                var cacheAllDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll));
                if (cacheAllDatas != null && cacheAllDatas.Any())
                {
                    var newCacheAllDatas = cacheAllDatas.ToList();
                    newCacheAllDatas.Add(contactGetModel);
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), newCacheAllDatas);
                }
                var cacheAllNonDeleteDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete));
                if (cacheAllNonDeleteDatas != null && cacheAllNonDeleteDatas.Any())
                {
                    var newCacheAllNonDeleteDatas = cacheAllNonDeleteDatas.ToList();
                    newCacheAllNonDeleteDatas.Add(contactGetModel);
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), newCacheAllNonDeleteDatas);
                }
                #endregion
                return contactGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var entity = _contactRepository.GetById(id);
                if (entity == null) return false;
                _contactRepository.Delete(entity);
                #region Redis Cache
                _redisService.Remove(string.Format(_contactCacheKeys.OneContact, id));
                var cacheAllDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll));
                if (cacheAllDatas != null && cacheAllDatas.Any())
                {
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), cacheAllDatas.Where(x => x.Id != id).ToList());
                }
                var cacheAllNonDeleteDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete));
                if (cacheAllNonDeleteDatas != null && cacheAllNonDeleteDatas.Any())
                {
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), cacheAllNonDeleteDatas.Where(x => x.Id != id).ToList());
                }
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var entity = await _contactRepository.GetByIdAsync(id);
                if (entity == null) return false;
                _contactRepository.Delete(entity);
                #region Redis Cache
                _redisService.Remove(string.Format(_contactCacheKeys.OneContact, id));
                var cacheAllDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll));
                if (cacheAllDatas != null && cacheAllDatas.Any())
                {
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), cacheAllDatas.Where(x => x.Id != id).ToList());
                }
                var cacheAllNonDeleteDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete));
                if (cacheAllNonDeleteDatas != null && cacheAllNonDeleteDatas.Any())
                {
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), cacheAllNonDeleteDatas.Where(x => x.Id != id).ToList());
                }
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContactGetModel>> GetAllAsync()
        {
            try
            {
                var entities = await _contactRepository.GetAllAsync();
                var list = entities.Select(x => new ContactGetModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Firm = x.Firm
                });
                #region Redis Cache
                _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), list);
                #endregion
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContactGetModel>> GetAllNonDeleteAsync()
        {
            try
            {
                var entities = await _contactRepository.Where(x => x.IsDeleted == false).ToListAsync();
                var list = entities.Select(x => new ContactGetModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Firm = x.Firm
                });
                #region Redis Cache
                _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), list);
                #endregion
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactGetModel> GetByIdAsync(string id)
        {
            try
            {
                var data = _redisService.Get<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, id));
                if (data != null) return data;
                var entity = await _contactRepository.GetByIdAsync(id);
                var contactGetModel = new ContactGetModel
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Firm = entity.Firm
                };
                #region Redis Cache
                _redisService.Set<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, entity.Id), contactGetModel);
                #endregion
                return contactGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SoftDelete(string id)
        {
            try
            {
                var entity = _contactRepository.GetById(id);
                if (entity == null) return false;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                _contactRepository.Update(entity);
                #region Redis Cache
                var cacheDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete));
                if (cacheDatas != null && cacheDatas.Any())
                {
                    var newCacheDatas = cacheDatas.Where(x => x.Id != id).ToList();
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), newCacheDatas);
                }
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(string id)
        {
            try
            {
                var entity = await _contactRepository.GetByIdAsync(id);
                if (entity == null) return false;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
                _contactRepository.Update(entity);
                #region Redis Cache
                var cacheDatas = _redisService.Get<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete));
                if (cacheDatas != null && cacheDatas.Any())
                {
                    var newCacheDatas = cacheDatas.Where(x => x.Id != id).ToList();
                    _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), newCacheDatas);
                }
                #endregion
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ContactGetModel Update(ContactUpdateModel model)
        {
            try
            {
                var entity = _contactRepository.GetById(model.Id);
                if (entity == null) throw new Exception("Not Found!");
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Firm = model.Firm;
                entity.UpdatedAt = DateTime.UtcNow;
                var data = _contactRepository.Update(entity);
                var contactGetModel = new ContactGetModel
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Firm = data.Firm
                };
                #region Redis Cache
                _redisService.Set<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, data.Id), contactGetModel);
                var entities = _contactRepository.GetAll();
                var listAll = entities.Select(x => new ContactGetModel
                {
                    Id = x.Id,
                    Firm = x.Firm,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });
                var listAllNonDelete = entities.Where(x => x.IsDeleted == false).Select(x => new ContactGetModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Firm = x.Firm
                });
                _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), listAll);
                _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), listAllNonDelete);
                #endregion
                return contactGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactGetModel> UpdateAsync(ContactUpdateModel model)
        {
            try
            {
                var entity = await _contactRepository.GetByIdAsync(model.Id);
                if (entity == null) throw new Exception("Not Found!");
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Firm = model.Firm;
                entity.UpdatedAt = DateTime.UtcNow;
                var data = _contactRepository.Update(entity);
                var contactGetModel = new ContactGetModel
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Firm = data.Firm
                };
                #region Redis Cache
                _redisService.Set<ContactGetModel>(string.Format(_contactCacheKeys.OneContact, data.Id), contactGetModel);
                var entities = await _contactRepository.GetAllAsync();
                var listAll = entities.Select(x => new ContactGetModel
                {
                    Id = x.Id,
                    Firm = x.Firm,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });
                var listAllNonDelete = entities.Where(x => x.IsDeleted == false).Select(x => new ContactGetModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Firm = x.Firm
                });
                _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAll), listAll);
                _redisService.Set<IEnumerable<ContactGetModel>>(string.Format(_contactCacheKeys.MultiContact, _contactCacheStringHelpers.FilterAllNonDelete), listAllNonDelete);
                #endregion
                return contactGetModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
