using Microsoft.AspNetCore.Mvc;
using skylance_backend.Data;
using skylance_backend.Models;
using skylance_backend.Enum;
using Castle.Components.DictionaryAdapter.Xml;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Populate_FlightBookingDetailController : Controller
    {
        private readonly SkylanceDbContext db;
        public Populate_FlightBookingDetailController(SkylanceDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult Populate()
        {
            var flightDetails = db.FlightDetails.ToDictionary(f => f.Id, f => f);
            var bookingDetails = db.BookingDetails.ToDictionary(b => b.BookingReferenceNumber, b => b);

            List<FlightBookingDetail> flightBookingDetailList = new List<FlightBookingDetail>
            {
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails["1"],
                    BookingDetail = bookingDetails["G66666"],
                    BaggageAllowance = 35,
                    SeatNumber = "12F",
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails["2"],
                    BookingDetail = bookingDetails["G66688"],
                    BaggageAllowance = 25,
                    SeatNumber = "10A",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2000
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails["3"],
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 45,
                    SeatNumber = "20C",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails["4"],
                    BookingDetail = bookingDetails["K78906"],
                    BaggageAllowance = 50,
                    SeatNumber = "13B",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Rebooked,
                    Fareamount = 1700
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails["5"],
                    BookingDetail = bookingDetails["L76543"],
                    BaggageAllowance = 25,
                    SeatNumber = "28D",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800
                }
            };

                db.AddRange(flightBookingDetailList);
                db.SaveChanges();

                return Ok("Flight booking detail records created successfully");
        }
    }
}
