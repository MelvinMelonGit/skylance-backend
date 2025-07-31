using Microsoft.AspNetCore.Mvc;
using skylance_backend.Data;
using skylance_backend.Models;
using skylance_backend.Enum;

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
                    FlightDetail = flightDetails["0c73462e-5e3f-4477-a16d-443186ac05fe"],
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
                    FlightDetail = flightDetails["1cfe33b8-b9da-4c32-b9fd-0ead164585d6"],
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
                    FlightDetail = flightDetails["1d69bbf3-fe80-4a34-ad03-45d845645ace"],
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
                    FlightDetail = flightDetails["2284e6e7-1aef-469c-842d-7f58a1aae6a9"],
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
                    FlightDetail = flightDetails["4dd3c408-6974-453c-b635-b9b2312cb838"],
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
