using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Models;
using skylance_backend.Services;
namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly SkylanceDbContext _db;
        private readonly RevenueService _revenueService;

        public RevenueController(SkylanceDbContext db, RevenueService revenueService)
        {
            _db = db;
            _revenueService = revenueService;
        }

        [HttpGet]
        [RequestTimeout(30)]
        public async Task<IActionResult> GetRevenue(string periodType)
        {

            await _revenueService.CalculateAndStoreRevenue();

            if (periodType != "month" && periodType != "year")
            {
                return new BadRequestObjectResult(new
                {
                    success = false,
                    message = "Invalid periodType. Allowed values: 'month' or 'year'"
                });
            }

            var revenueData = await _db.AirlineRevenue
                .Where(r => r.PeriodType == periodType)
                .GroupBy(r => r.Period)
                .Select(g => new
                {
                    period = g.Key,
                    revenue = g.Sum(x => x.Revenue)
                })
                .OrderBy(x => x.period)
                .ToListAsync();

            return new OkObjectResult(new
            {
                success = true,
                period = periodType,
                data = revenueData
            });

            /*var revenueData = await _db.AirlineRevenue
                    .Where(r => r.Period == period&&r.Period.EndsWith(period))
                    .GroupBy(r => r.Period)
                    .Select(g => new
                    {
                        period = g.Key,
                        revenue = g.Sum(x => x.Revenue)
                    })
                    .OrderBy(x => x.period)
                    .ToListAsync();*/


        }




        /*
        private bool IsMonthIdentifier(string period)
        {
            var monthNames = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            return monthNames.Contains(period);
        }

        private bool IsYearIdentifier(string period)
        {
            return int.TryParse(period, out int year) && year >= 2000 ;
        }
        private string ConvertMonthAbbreviationToNumber(string month)
        {
            var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            var monthIndex = Array.IndexOf(months, month) + 1;
            return monthIndex.ToString("00"); 
        }*/
    }
}
   
