using ContactApp.API.Interfaces;
using ContactApp.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Services
{
    public class ReportService : IReportService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactInfoRepository _contactInfoRepository;

        public ReportService(IContactRepository contactRepository, IContactInfoRepository contactInfoRepository)
        {
            _contactRepository = contactRepository;
            _contactInfoRepository = contactInfoRepository;
        }

        public async Task<IEnumerable<ReportGetModel>> GetBasicReportAsync()
        {
            try
            {
                var accounts = await _contactRepository.Where(x => x.IsDeleted == false).ToListAsync();
                var infos = await _contactInfoRepository.Where(x => x.IsDeleted == false).ToListAsync();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
