using Microsoft.AspNetCore.Mvc;
using skylance_backend.Data;
using skylance_backend.Models;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Populate_BookingDetailController : ControllerBase
    {
        private readonly SkylanceDbContext db;

        public Populate_BookingDetailController (SkylanceDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult Populate()
        {
            if (db.BookingDetails.Any())
                return BadRequest("Data already seeded.");

            var appUsers = db.AppUsers.ToDictionary(a => a.Email, a => a);
            var fligthDetails = db.FlightDetails.ToDictionary(f => f.Aircraft, f => f);

            List<BookingDetail> bookingDetailsList = new List<BookingDetail>
            {
                BookingReferenceNumber = "G66666",
                FareAmount = 

            }
        }
    }
}
