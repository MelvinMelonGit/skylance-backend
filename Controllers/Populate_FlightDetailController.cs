using Microsoft.AspNetCore.Mvc;
using skylance_backend.Data;
using skylance_backend.Models;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Populate_FlightDetailController : Controller
    {
        private readonly SkylanceDbContext db;
        public Populate_FlightDetailController(SkylanceDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult Populate()
        {
            if (db.FlightDetails.Any())
                return BadRequest("Data already seeded.");

            var aircrafts = db.Aircraft.ToDictionary(ac => ac.FlightNumber, ac => ac);

            var airports = db.Airports.ToDictionary(ap => ap.IataCode, ap => ap);

            List<FlightDetail> flightDetailList = new List<FlightDetail>
            {
                new FlightDetail {
                    Aircraft = aircrafts["SQ322"],
                    OriginAirport = airports["SIN"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 8, 5, 8, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 5, 16, 30, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 120,
                    SeatsSold = 140,
                    Distance=6200
                },

                new FlightDetail
                {
                    Aircraft = aircrafts["JL1"],
                    OriginAirport = airports["NRT"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 6, 22, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 7, 7, 0, 0),
                    IsHoliday = true,
                    FlightStatus = "Scheduled",
                    CheckInCount = 80,
                    SeatsSold = 85,
                    Distance=5300
                },

                new FlightDetail
                {
                    Aircraft = aircrafts["MH1"],
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2025, 8, 7, 15, 30, 0),
                    ArrivalTime = new DateTime(2025, 8, 7, 20, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Delayed",
                    CheckInCount = 100,
                    SeatsSold = 110,
                    Distance=4500
                },

                new FlightDetail
                {
                    Aircraft = aircrafts["KE85"],
                    OriginAirport = airports["ICN"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 8, 8, 6, 45, 0),
                    ArrivalTime = new DateTime(2025, 8, 8, 14, 30, 0),
                    IsHoliday = false,
                    FlightStatus = "Cancelled",
                    CheckInCount = 0,
                    SeatsSold = 0,
                    Distance=7800
                },

                new FlightDetail {
                    Aircraft = aircrafts["QF1"],
                    OriginAirport = airports["CBR"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 9, 10, 15, 0),
                    ArrivalTime = new DateTime(2025, 8, 9, 16, 45, 0),
                    IsHoliday = true,
                    FlightStatus = "Scheduled",
                    CheckInCount = 130,
                    SeatsSold = 145,
                    Distance=6200
                },
            };

            db.FlightDetails.AddRange(flightDetailList);
            db.SaveChanges();

            return Ok("Flight Details seeded successfully.");
        }
    }
}














