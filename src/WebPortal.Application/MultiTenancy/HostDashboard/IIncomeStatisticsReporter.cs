using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPortal.MultiTenancy.HostDashboard.Dto;

namespace WebPortal.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}