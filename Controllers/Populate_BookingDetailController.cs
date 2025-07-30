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

            List<BookingDetail> bookingDetailsList = new List<BookingDetail>
            {
                new BookingDetail
                {
                    BookingReferenceNumber = "G66666",
                    AppUser = appUsers["teng@gmail.com"]
                }
            };

                db.BookingDetails.AddRange(bookingDetailsList);
                db.SaveChanges();

                return Ok("Booking Details seeded successfully.");
        }
    }
}
