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
            /*db.FlightDetails.RemoveRange(db.FlightDetails);
            if (db.FlightBookingDetails.Any())
                return BadRequest("Data already seeded.");*/

            var flightDetails = db.FlightDetails.ToDictionary(f => f.Id, f => f);
            var bookingDetails = db.BookingDetails.ToDictionary(b => b.BookingReferenceNumber, b => b);

            List<FlightBookingDetail> flightBookingDetailList = new List<FlightBookingDetail>
            {                
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[12],
                    BookingDetail = bookingDetails["G66666"],
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200,
                    Prediction = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[13],
                    BookingDetail = bookingDetails["G66688"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Emergency,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2000,
                    Prediction = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[14],
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[15],
                    BookingDetail = bookingDetails["K78906"],
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1700,
                    Prediction = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[5],
                    BookingDetail = bookingDetails["L76543"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800,
                    Prediction = null
                },               

                 new FlightBookingDetail
                {
                    FlightDetail = flightDetails[1],
                    BookingDetail = bookingDetails["A00835"],
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200,
                    Prediction = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[4],
                    BookingDetail = bookingDetails["H37766"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2000,
                    Prediction = Prediction.No_Show
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[6],
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2300,
                    Prediction = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[4],
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1700,
                    Prediction = null
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[8],
                    BookingDetail = bookingDetails["U24899"],
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
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[27],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BaggageAllowance = 440,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2100,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },
                 new FlightBookingDetail
                {
                    FlightDetail = flightDetails[26],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BaggageAllowance = 30,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1500,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },    
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[25],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["A00835"],
                    BaggageAllowance = 0,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1000,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[24],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["A00835"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2000,
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
