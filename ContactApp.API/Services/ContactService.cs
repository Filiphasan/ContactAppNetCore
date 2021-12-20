using ContactApp.API.Interfaces;
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

        public ContactService(IContactRepository contactRepository, IRedisService redisService)
        {
            _contactRepository = contactRepository;
            _redisService = redisService;
        }
    }
}
