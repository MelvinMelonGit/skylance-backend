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
            if (db.FlightBookingDetails.Any())
                return BadRequest("Data already seeded.");

            var flightDetails = db.FlightDetails.ToDictionary(f => f.Id, f => f);
            var bookingDetails = db.BookingDetails.ToDictionary(b => b.BookingReferenceNumber, b => b);

            List<FlightBookingDetail> flightBookingDetailList = new List<FlightBookingDetail>
            {                
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[1],                    // overbooked flight (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["G66666"],
                    BookingDate = new DateTime(2024, 7, 28, 3, 45, 0),
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200,
                    Prediction = null,
                    Class = Class.First,
                    SpecialRequest = SpecialRequest.AisleSeat
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[2],                    // overbooked flight (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["G66688"],
                    BookingDate = new DateTime(2024, 10, 18, 8, 0, 0),
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Emergency,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2000,
                    Prediction = null,
                    Class = Class.Business,
                    SpecialRequest = SpecialRequest.Vegan
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[3],                    // normal flight for check-in (beng@gmail.com for Elsie Bong)
                    BookingDetail = bookingDetails["J01927"],
                    BookingDate = new DateTime(2025, 8, 3, 11, 0, 0),
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show,
                    Class =  Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Diabetic

                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[10],                    // normal flight for check-in (meng@gmail.com for Mary Poppins)
                    BookingDetail = bookingDetails["K78906"],
                    BookingDate = new DateTime(2024, 12, 10, 12, 12, 0),
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.UMNR
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[5],                    // overbooked flight (leng@gmail.com for Rocky Lim)
                    BookingDetail = bookingDetails["L76543"],
                    BookingDate = new DateTime(2024, 11, 20, 2, 0, 0),
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800,
                    Prediction = null,
                    Class = Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Wheelchair
                },               

                 new FlightBookingDetail                                
            {
                    FlightDetail = flightDetails[9],                    // overbooked flight (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["A00835"],
                    BookingDate = new DateTime(2024, 3, 23, 10, 0, 0),
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[4],                    // normal flight for check-in (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["H37766"],
                    BookingDate = new DateTime(2025, 6, 10, 10, 0, 0),
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2000,
                    Prediction = Prediction.No_Show,
                    Class = Class.PremiumEconomy,
                    SpecialRequest = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[6],                    // normal flight for check-in (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BookingDate = new DateTime(2024, 8, 19, 8, 0, 0),
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2300,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[7],                    // overbooked flight (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["H54321"],
                    BookingDate = new DateTime(2025, 5, 20, 4, 15, 0),
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.Vegan
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[8],                    // normal flight for check-in (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["U24899"],
                    BookingDate = new DateTime(2024, 9, 27, 7, 0, 0),
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },

                 new FlightBookingDetail
                {
                    FlightDetail = flightDetails[16],                    // past flight (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["G66666"],
                    BookingDate = new DateTime(2025, 3, 14, 8, 55, 0),
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1200,
                    Prediction = null,
                    Class = Class.First,
                    SpecialRequest = SpecialRequest.AisleSeat
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[17],                    // past flight (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["H37766"],
                    BookingDate = new DateTime(2025, 2, 20, 8, 14, 0),
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1200,
                    Prediction = null,
                    Class = Class.First,
                    SpecialRequest = SpecialRequest.AisleSeat
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[18],                    // past flight (meng@gmail.com for Mary Poppins)
                    BookingDetail = bookingDetails["K78906"],
                    BookingDate = new DateTime(2024, 11, 30, 4, 0, 0),
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.UMNR
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[19],                    // past flight (meng@gmail.com for Mary Poppins)
                    BookingDetail = bookingDetails["K78906"],
                    BookingDate = new DateTime(2024, 11, 20, 8, 0, 0),
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.UMNR
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[33],                    // past flight (meng@gmail.com for Mary Poppins)
                    BookingDetail = bookingDetails["K78906"],
                    BookingDate = new DateTime(2024, 4, 11, 8, 0, 0),
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.UMNR
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[31],                    // past flight (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["A00835"],
                    BookingDate = new DateTime(2025, 2, 20, 9, 30, 0),
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 800,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[32],                    // past flight (beng@gmail.com for Elsie Bong)
                    BookingDetail = bookingDetails["J01927"],
                    BookingDate = new DateTime(2025, 3, 2, 3, 0, 0),
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show,
                    Class =  Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Diabetic
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[30],                    // past flight (beng@gmail.com for Elsie Bong)
                    BookingDetail = bookingDetails["J01927"],
                    BookingDate = new DateTime(2024, 8, 2, 5, 30, 0),
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show,
                    Class =  Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Diabetic
                },

                  new FlightBookingDetail
                {
                    FlightDetail = flightDetails[29],                    // past flight (beng@gmail.com for Elsie Bong)
                    BookingDetail = bookingDetails["J01927"],
                    BookingDate = new DateTime(2025, 1, 27, 8, 15, 0),
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show,
                    Class =  Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Diabetic
                },

                   new FlightBookingDetail
                {
                    FlightDetail = flightDetails[28],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BookingDate = new DateTime(2024, 10, 20, 5, 27, 0),
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },

            };

                db.AddRange(flightBookingDetailList);
                db.SaveChanges();

                return Ok("Flight booking detail records created successfully");
        }
    }
}
