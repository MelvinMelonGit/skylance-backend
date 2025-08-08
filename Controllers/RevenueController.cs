using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Models;
using skylance_backend.Services;
using System.Globalization;
namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevenueController : Controller
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

            var revenueData = periodType == "month"? await GetMonthlyRevenueData(): await GetYearlyRevenueData();

            return Ok(new
            {
                success = true,
                periodType = periodType,
                data = revenueData
            });

            

        }

        private async Task<object> GetMonthlyRevenueData()
        {
            return await _db.AirlineRevenue
       .Where(r => r.PeriodType == "month")
       .GroupBy(r =>int.Parse(r.Period.Substring(5, 2))) 
       .Select(g => new 
       {
           period = CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key), 
           Revenue = g.Sum(x => x.Revenue) 
       })
       .OrderBy(x =>DateTime.ParseExact(x.period, "MMM", CultureInfo.InvariantCulture).Month) 
       .ToListAsync();
        }

        private async Task<object> GetYearlyRevenueData()
        {
            return await _db.AirlineRevenue
                 .Where(r => r.PeriodType == "year") 
                 .GroupBy(r => r.Period)             
                 .Select(g => new
                 {
                     period = g.Key,
                     revenue = g.Sum(x => x.Revenue) 
                 })
                 .OrderBy(x => x.period)             
                 .ToListAsync();
        }
    }
}
   
