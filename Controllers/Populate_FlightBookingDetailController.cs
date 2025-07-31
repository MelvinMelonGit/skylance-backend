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
                    FlightDetail = flightDetails[1],
                    BookingDetail = bookingDetails["G66666"],
                    TravelPurpose = "Business",
                    BaggageAllowance = 35,
                    SelectedSeat = "12F",
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 200
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[2],
                    BookingDetail = bookingDetails["G66688"],
                    TravelPurpose = "Family",
                    BaggageAllowance = 25,
                    SelectedSeat = "10A",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 200
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[3],
                    BookingDetail = bookingDetails["J01927"],
                    TravelPurpose = "Leisure",
                    BaggageAllowance = 45,
                    SelectedSeat = "20C",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Cancelled,
                    Fareamount = 200
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[4],
                    BookingDetail = bookingDetails["K78906"],
                    TravelPurpose = "Emergency",
                    BaggageAllowance = 50,
                    SelectedSeat = "13B",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Rebooked,
                    Fareamount = 200
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[5],
                    BookingDetail = bookingDetails["L76543"],
                    TravelPurpose = "Leisure",
                    BaggageAllowance = 25,
                    SelectedSeat = "28D",
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 200
                }
            };

                db.AddRange(flightBookingDetailList);
                db.SaveChanges();

                return Ok("Flight booking detail records created successfully");
        }
    }
}
