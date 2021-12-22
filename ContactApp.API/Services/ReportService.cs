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
                var list = new List<ReportGetModel>();
                var accounts = await _contactRepository.Where(x => x.IsDeleted == false).ToListAsync();
                var infos = await _contactInfoRepository.Where(x => x.IsDeleted == false).ToListAsync();
                var allLocationsWithCounList = infos.Where(x => x.Key == "Konum").GroupBy(x => x.Value).Select(x => new
                {
                    Location = x.Key,
                    LocationCount = x.Count()
                }).ToList();
                foreach (var item in allLocationsWithCounList)
                {
                    var contactCount = 0;
                    var phoneCount = 0;
                    var datas1 = infos.Where(x => x.Key == "Konum" && x.Value == item.Location).ToList();
                    contactCount = datas1.GroupBy(x => x.ContactId).Count();
                    foreach (var item2 in datas1.GroupBy(x => x.ContactId).ToList())
                    {
                        phoneCount = phoneCount + infos.Where(x => x.Key == "Telefon Numarası" && x.ContactId == item2.Key).Count();
                    }
                    var reportModel = new ReportGetModel
                    {
                        Location = item.Location,
                        LocationCount = item.LocationCount,
                        ContactCountInLocation = contactCount,
                        NumberCountInLocation = phoneCount
                    };
                    list.Add(reportModel);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
