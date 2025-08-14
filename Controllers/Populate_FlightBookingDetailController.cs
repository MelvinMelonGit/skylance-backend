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
                    FlightDetail = flightDetails[2],                    // Scenario 3 overbooked flight JL1 (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["G66666"],
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200,
                    Prediction = null,
                    Class = Class.First,
                    SpecialRequest = SpecialRequest.AisleSeat,
                    BookingDate = new DateTime(2025, 1, 17, 15, 30, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[9],                    // overbooked flight (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["G66688"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Emergency,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2000,
                    Prediction = null,
                    Class = Class.Business,
                    SpecialRequest = SpecialRequest.Vegan,
                    BookingDate = new DateTime(2024, 2, 17, 15, 0, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[3],                    // Scenario 1 normal flight MH1 for check-in (beng@gmail.com for Elsie Bong)
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show,
                    Class =  Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Diabetic,
                    BookingDate = new DateTime(2024, 5, 20, 10, 30, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[10],                    // normal flight for check-in (meng@gmail.com for Mary Poppins)
                    BookingDetail = bookingDetails["K78906"],
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.UMNR,
                    BookingDate = new DateTime(2024, 5, 29, 5, 30, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[2],                    // Scenario 4 overbooked flight JL1 (leng@gmail.com for Rocky Lim)
                    BookingDetail = bookingDetails["L76543"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800,
                    Prediction = null,
                    Class = Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Wheelchair,
                    BookingDate = new DateTime(2024, 9, 20, 7, 30, 0)
                },

                 new FlightBookingDetail
            {
                    FlightDetail = flightDetails[3],                    // Scenario 2 normal flight MH1 for check-in (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["A00835"],
                    BaggageAllowance = 35,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = true,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1200,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 10, 10, 5, 30, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[4],                    // normal flight for check-in (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["H37766"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2000,
                    Prediction = Prediction.No_Show,
                    Class = Class.PremiumEconomy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 20, 8, 30, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[6],                    // normal flight for check-in (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2300,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2025, 3, 20, 11, 30, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[7],                    // overbooked flight (teng@gmail.com for John Smith)
                    BookingDetail = bookingDetails["H54321"],
                    BaggageAllowance = 50,
                    TravelPurpose = TravelPurpose.Business,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = SpecialRequest.Vegan,
                    BookingDate = new DateTime(2024, 7, 29, 9, 0, 0)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[8],                    // normal flight for check-in (seng@gmail.com for Linda Too)
                    BookingDetail = bookingDetails["U24899"],
                    BaggageAllowance = 25,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 20, 3, 30, 0)
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
                    SpecialRequest = SpecialRequest.AisleSeat,
                    BookingDate = new DateTime(2025, 3, 11, 8, 10, 0)
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
                    SpecialRequest = SpecialRequest.AisleSeat,
                    BookingDate = new DateTime(2024, 8, 30, 6, 30, 0)
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
                    SpecialRequest = SpecialRequest.UMNR,
                    BookingDate = new DateTime(2024, 11, 8, 3, 0, 0)
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
                    SpecialRequest = SpecialRequest.UMNR,
                    BookingDate = new DateTime(2024, 12, 27, 7, 0, 0)
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
                    SpecialRequest = SpecialRequest.UMNR,
                    BookingDate = new DateTime(2024, 11, 8)
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
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 6, 8)
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
                    SpecialRequest = SpecialRequest.Diabetic,
                    BookingDate = new DateTime(2024, 11, 20)
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
                    SpecialRequest = SpecialRequest.Diabetic,
                    BookingDate = new DateTime(2024, 6, 8)
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
                    SpecialRequest = SpecialRequest.Diabetic,
                    BookingDate = new DateTime(2024, 11, 10)
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
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 1, 8)
                },
                   //Zhuoxuan added
                   new FlightBookingDetail
                {
                    FlightDetail = flightDetails[27],                    // past flight (beng@gmail.com for Elsie Bong)
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Family,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = Prediction.No_Show,
                    Class =  Class.PremiumEconomy,
                    SpecialRequest = SpecialRequest.Diabetic,
                    BookingDate = new DateTime(2024, 12, 11)
                },

                   new FlightBookingDetail
                {
                    FlightDetail = flightDetails[26],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 8, 8)
                },
                   new FlightBookingDetail
                {
                    FlightDetail = flightDetails[24],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1900,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 5, 19)
                },
                   new FlightBookingDetail
                {
                    FlightDetail = flightDetails[25],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67556"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1900,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 20)
                },
                   new FlightBookingDetail
                {
                    FlightDetail = flightDetails[34],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67524"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1900,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2025, 4, 11)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[35],                    // past flight (teng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H37724"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2000,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2025, 1, 8)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[36],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["U24824"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2200,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 10, 22)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[37],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67523"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2023, 11, 22)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[38],                    // past flight (teng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H37723"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2600,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 8, 11)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[39],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["U24823"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2500,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 12, 30)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[40],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67522"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2000,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 10)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[41],                    // past flight (teng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H37722"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2100,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 12, 11)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[42],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["U24822"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2300,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 9, 10)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[43],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67521"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1900,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 27)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[44],                    // past flight (teng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H37721"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 3, 17)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[45],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["U24821"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1700,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 15)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[46],                    // past flight (seng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H67520"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2100,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 28)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[47],                    // past flight (teng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["H37720"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2000,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 5, 19)
                },
                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[48],                    // past flight (leng@gmail.com for Rocky Lim)     
                    BookingDetail = bookingDetails["U24820"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1900,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 10, 14)
                },

                 new FlightBookingDetail
                {
                    FlightDetail = flightDetails[49],                    // For dashboard summary - Today's flight, 14 Aug 2025     
                    BookingDetail = bookingDetails["H37721"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1500,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 11, 24)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[52],                    // For dashboard summary - Today's flight, 14 Aug 2025     
                    BookingDetail = bookingDetails["H67523"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 1080,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2025, 2, 18)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[51],                    // For dashboard summary - Today's flight, 14 Aug 2025     
                    BookingDetail = bookingDetails["H37724"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 800,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 7, 18)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[51],                    // For dashboard summary - Today's flight, 14 Aug 2025     
                    BookingDetail = bookingDetails["U24821"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 2160,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 12, 20)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[49],                    // For dashboard summary - Today's flight, 14 Aug 2025     
                    BookingDetail = bookingDetails["U24820"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = 900,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2025, 4, 28)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[54],                    // For dashboard summary - Yesterday's flight, 13 Aug 2025     
                    BookingDetail = bookingDetails["J01927"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2000,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 10, 27)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[56],                    // For dashboard summary - Yesterday's flight, 13 Aug 2025     
                    BookingDetail = bookingDetails["L76543"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 1860,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 7, 7)
                },

                new FlightBookingDetail
                {
                    FlightDetail = flightDetails[56],                    // For dashboard summary - Yesterday's flight, 13 Aug 2025     
                    BookingDetail = bookingDetails["A00835"],
                    BaggageAllowance = 45,
                    TravelPurpose = TravelPurpose.Leisure,
                    SeatNumber = null,
                    RequireSpecialAssistance = false,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = 2450,
                    Prediction = null,
                    Class = Class.Economy,
                    SpecialRequest = null,
                    BookingDate = new DateTime(2024, 6, 6)
                },

            };

            db.AddRange(flightBookingDetailList);
            db.SaveChanges();

            return Ok("Flight booking detail records created successfully");
        }
    }
}
