using ContactApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportGetModel>> GetBasicReportAsync();
    }
}
