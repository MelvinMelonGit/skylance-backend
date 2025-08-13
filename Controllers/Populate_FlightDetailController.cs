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
            /*if (db.FlightDetails.Any())
                return BadRequest("Data already seeded.");*/

            var aircrafts = db.Aircraft.ToDictionary(ac => ac.FlightNumber, ac => ac);

            var airports = db.Airports.ToDictionary(ap => ap.IataCode, ap => ap);

            List<FlightDetail> flightDetailList = new List<FlightDetail>
            {                
                new FlightDetail {                          // flightDetails[1] - for overbooked scenario
                    Aircraft = aircrafts["SQ322"],
                    OriginAirport = airports["SIN"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 8, 20, 8, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 21, 16, 30, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 181,
                    OverbookingCount = 0,
                    SeatsSold = 140,
                    Distance=6200,
                    NumberOfCrew = 6,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail                            // flightDetails[2] - for overbooked scenario
                {
                    Aircraft = aircrafts["JL1"],
                    OriginAirport = airports["NRT"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 16, 7, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 16, 22, 0, 0),
                    IsHoliday = true,
                    FlightStatus = "Scheduled",
                    CheckInCount = 151,
                    OverbookingCount = 0,
                    SeatsSold = 85,
                    Distance=5300,
                    NumberOfCrew = 5,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail                            // flightDetails[3] - for normal check-in scenario
                {
                    Aircraft = aircrafts["MH1"],
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2025, 8, 17, 15, 30, 0),
                    ArrivalTime = new DateTime(2025, 8, 17, 20, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 100,
                    OverbookingCount = 0,
                    SeatsSold = 110,
                    Distance=4500,
                    NumberOfCrew = 15,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail                            // flightDetails[4] - for normal check-in scenario
                {
                    Aircraft = aircrafts["KE85"],
                    OriginAirport = airports["ICN"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 9, 8, 6, 45, 0),
                    ArrivalTime = new DateTime(2025, 9, 9, 14, 30, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 0,
                    Distance=7800,
                    NumberOfCrew = 14,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {                          // flightDetails[5] - for overbooked scenario
                    Aircraft = aircrafts["QF1"],
                    OriginAirport = airports["CBR"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 18, 10, 15, 0),
                    ArrivalTime = new DateTime(2025, 8, 18, 16, 45, 0),
                    IsHoliday = true,
                    FlightStatus = "Scheduled",
                    CheckInCount = 130,
                    OverbookingCount = 0,
                    SeatsSold = 145,
                    Distance=6200,
                    NumberOfCrew = 4,
                    Prediction = null,
                    Probability = null
                },
                
                new FlightDetail {                          // flightDetails[6] - for normal check-in scenario
                    Aircraft = aircrafts["SQ12"],
                    OriginAirport = airports["SIN"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 8, 17, 8, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 17, 17, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 200,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 6300,
                    NumberOfCrew = 22,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {                          // flightDetails[7] - for overbooked scenario
                    Aircraft = aircrafts["QF93"],
                    OriginAirport = airports["CBR"],
                    DestinationAirport = airports["AUH"],
                    DepartureTime = new DateTime(2025, 8, 18, 13, 45, 0),
                    ArrivalTime = new DateTime(2025, 8, 18, 21, 30, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 237,
                    OverbookingCount = 0,
                    SeatsSold = 220,
                    Distance = 12000,
                    NumberOfCrew = 13,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {                          // flightDetails[8] - for normal check-in scenario
                    Aircraft = aircrafts["EY101"],
                    OriginAirport = airports["AUH"],
                    DestinationAirport = airports["ZRH"],
                    DepartureTime = new DateTime(2025, 8, 19, 2, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 19, 7, 30, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 400,
                    OverbookingCount = 0,
                    SeatsSold = 450,
                    Distance = 4800,
                    NumberOfCrew = 5,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {                          // flightDetails[9] - for overbooked scenario
                    Aircraft = aircrafts["LX38"],
                    OriginAirport = airports["ZRH"],
                    DestinationAirport = airports["HAN"],
                    DepartureTime = new DateTime(2025, 8, 18, 13, 0, 0),
                    ArrivalTime = new DateTime(2025, 8, 18, 6, 15, 0),
                    IsHoliday = true,
                    FlightStatus = "Scheduled",
                    CheckInCount = 340,
                    OverbookingCount = 1,
                    SeatsSold = 230,
                    Distance = 9200,
                    NumberOfCrew = 4,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {                          // flightDetails[10] - for normal check-in scenario
                    Aircraft = aircrafts["VN50"],
                    OriginAirport = airports["HAN"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 17, 11, 30, 0),
                    ArrivalTime = new DateTime(2025, 8, 17, 14, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Scheduled",
                    CheckInCount = 295,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 2200,
                    NumberOfCrew = 10,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {
                    Aircraft = aircrafts["KE621"],
                    OriginAirport = airports["ICN"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 11, 13, 30, 0),  // departed before 11 Aug 14:00
                    ArrivalTime = new DateTime(2025, 8, 11, 18, 0, 0),      // arriving after 11 Aug 15:00
                    IsHoliday = false,
                    FlightStatus = "In-Flight",
                    CheckInCount = 150,
                    OverbookingCount = 0,
                    SeatsSold = 140,
                    Distance = 5300,
                    NumberOfCrew = 8,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {
                    Aircraft = aircrafts["SQ26"],
                    OriginAirport = airports["SIN"],
                    DestinationAirport = airports["ZRH"],
                    DepartureTime = new DateTime(2025, 8, 11, 7, 0, 0),  // departed before 11 Aug 14:00
                    ArrivalTime = new DateTime(2025, 8, 11, 16, 30, 0),      // arriving after 11 Aug 15:00
                    IsHoliday = false,
                    FlightStatus = "In-Flight",
                    CheckInCount = 150,
                    OverbookingCount = 0,
                    SeatsSold = 140,
                    Distance = 5300,
                    NumberOfCrew = 8,
                    Prediction = null,
                    Probability = null,
                },

                new FlightDetail {
                    Aircraft = aircrafts["JL37"],
                    OriginAirport = airports["SIN"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2025, 8, 11, 8, 45, 0),  // departed before 11 Aug 14:00
                    ArrivalTime = new DateTime(2025, 8, 11, 17, 30, 0),      // arriving after 11 Aug 15:00
                    IsHoliday = false,
                    FlightStatus = "In-Flight",
                    CheckInCount = 150,
                    OverbookingCount = 0,
                    SeatsSold = 140,
                    Distance = 5300,
                    NumberOfCrew = 8,
                    Prediction = null,
                    Probability = null
                },

                new FlightDetail {
                    Aircraft = aircrafts["JL37"],
                    OriginAirport = airports["NRT"],
                    DestinationAirport = airports["HAN"],
                    DepartureTime = new DateTime(2025, 8, 11, 6, 15, 0),  // departed before 11 Aug 14:00
                    ArrivalTime = new DateTime(2025, 8, 11, 20, 00, 0),      // arriving after 11 Aug 15:00
                    IsHoliday = false,
                    FlightStatus = "In-Flight",
                    CheckInCount = 150,
                    OverbookingCount = 0,
                    SeatsSold = 140,
                    Distance = 5300,
                    NumberOfCrew = 8,
                    Prediction = null,
                    Probability = null
                },

                 new FlightDetail {
                    Aircraft = aircrafts["JL1"],
                    OriginAirport = airports["AUH"],
                    DestinationAirport = airports["KUL"],
                    DepartureTime = new DateTime(2025, 8, 11, 13, 45, 0),  // departed before 11 Aug 14:00
                    ArrivalTime = new DateTime(2025, 8, 11, 22, 00, 0),      // arriving after 11 Aug 15:00
                    IsHoliday = false,
                    FlightStatus = "In-Flight",
                    CheckInCount = 150,
                    OverbookingCount = 0,
                    SeatsSold = 140,
                    Distance = 5300,        
                    NumberOfCrew = 8,
                    Prediction = null,
                    Probability = null
                 },

                 new FlightDetail {                         // flightDetails[16]
                    Aircraft = aircrafts["QF1"],
                    OriginAirport = airports["CBR"],
                    DestinationAirport = airports["AUH"],
                    DepartureTime = new DateTime(2025, 8, 10, 8, 45, 0),   // departed before 10 Aug 14:00 (11 Aug minus 1 day)
                    ArrivalTime = new DateTime(2025, 8, 10, 16, 0, 0),      // arriving after 10 Aug 15:00 (11 Aug minus 1 day)
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 160,
                    OverbookingCount = 0,
                    SeatsSold = 155,
                    Distance = 6300,
                    NumberOfCrew = 7,
                    Prediction = null,
                    Probability = null
                 },

                 new FlightDetail {                         // flightDetails[17]
                    Aircraft = aircrafts["KL605"],
                    OriginAirport = airports["NRT"],
                    DestinationAirport = airports["HAN"],
                    DepartureTime = new DateTime(2025, 8, 10, 11, 00, 0),   // departed before 10 Aug 14:00 (11 Aug minus 1 day)
                    ArrivalTime = new DateTime(2025, 8, 10, 19, 30, 0),      // arriving after 10 Aug 15:00 (11 Aug minus 1 day)
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 180,
                    OverbookingCount = 0,
                    SeatsSold = 170,
                    Distance = 3700,
                    NumberOfCrew = 9,
                    Prediction = null,
                    Probability = null
                 },

                 new FlightDetail {                         // flightDetails[18]
                    Aircraft = aircrafts["EY101"],
                    OriginAirport = airports["ZRH"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 8, 10, 10, 15, 0),   // departed before 10 Aug 14:00 (11 Aug minus 1 day)
                    ArrivalTime = new DateTime(2025, 8, 10, 17, 25, 0),      // arriving after 10 Aug 15:00 (11 Aug minus 1 day)
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 225,
                    Distance = 10300,
                    NumberOfCrew = 11,
                    Prediction = null,
                    Probability = null
                 },

                 new FlightDetail {                         // flightDetails[19]
                    Aircraft = aircrafts["JL1"],
                    OriginAirport = airports["ICN"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 8, 10, 10, 15, 0),   // departed before 10 Aug 14:00 (11 Aug minus 1 day)
                    ArrivalTime = new DateTime(2025, 8, 10, 17, 25, 0),      // arriving after 10 Aug 15:00 (11 Aug minus 1 day)
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 225,
                    Distance = 10300,
                    NumberOfCrew = 11,
                    Prediction = null,
                    Probability = null
                 },

                 new FlightDetail {                                     // Flight for Jan 2025
                    Aircraft = aircrafts["LH492"],
                    OriginAirport = airports["FRA"],
                    DestinationAirport = airports["GRU"],
                    DepartureTime = new DateTime(2025, 1, 9, 11, 30, 0),
                    ArrivalTime = new DateTime(2025, 1, 9, 14, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 200,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 2200,
                    NumberOfCrew = 10,
                    Prediction = null,
                    Probability = null
                },

                  new FlightDetail {                                    // Flight for Jan 2025
                    Aircraft = aircrafts["LA8070"],
                    OriginAirport = airports["GRU"],
                    DestinationAirport = airports["EZE"],
                    DepartureTime = new DateTime(2025, 1, 18, 11, 30, 0),
                    ArrivalTime = new DateTime(2025, 1, 18, 14, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 200,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 2200,
                    NumberOfCrew = 10,
                    Prediction = null,
                    Probability = null
                },

                  new FlightDetail {                                    // Flight for Feb 2025
                    Aircraft = aircrafts["BA283"],
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["CBR"],
                    DepartureTime = new DateTime(2025, 2, 9, 11, 30, 0),
                    ArrivalTime = new DateTime(2025, 2, 9, 14, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 200,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 2200,
                    NumberOfCrew = 10,
                    Prediction = null,
                    Probability = null
                },

                  new FlightDetail {                                    // Flight for Feb 2025
                    Aircraft = aircrafts["AR1301"],
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["HAN"],
                    DepartureTime = new DateTime(2025, 2, 9, 11, 30, 0),
                    ArrivalTime = new DateTime(2025, 2, 9, 13, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 120,
                    OverbookingCount = 0,
                    SeatsSold = 150,
                    Distance = 1150,        
                    NumberOfCrew = 6,
                    Prediction = null,
                    Probability = null
                  },

                  new FlightDetail {                                    // Flight for Mar 2025
                    Aircraft = aircrafts["KL605"],
                    OriginAirport = airports["AMS"],
                    DestinationAirport = airports["ZRH"],
                    DepartureTime = new DateTime(2025, 3, 25, 9, 45, 0),   
                    ArrivalTime = new DateTime(2025, 3, 25, 11, 15, 0),    
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 180,
                    OverbookingCount = 0,
                    SeatsSold = 300,            
                    Distance = 615,             
                    NumberOfCrew = 10,          
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                                    // Flight for Mar 2025
                    Aircraft = aircrafts["LA8070"],
                    OriginAirport = airports["LHR"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 3, 28, 21, 30, 0),  
                    ArrivalTime = new DateTime(2025, 3, 28, 17, 15, 0),   
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 280,
                    OverbookingCount = 0,
                    SeatsSold = 310,           
                    Distance = 10845,          
                    NumberOfCrew = 15,         
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                                    // Flight for Apr 2025
                    Aircraft = aircrafts["QF1"],
                    OriginAirport = airports["GRU"],
                    DestinationAirport = airports["KUL"],
                    DepartureTime = new DateTime(2025, 4, 8, 22, 0, 0),  
                    ArrivalTime = new DateTime(2025, 4, 8, 18, 0, 0),    
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 250,
                    OverbookingCount = 0,
                    SeatsSold = 240,               
                    Distance = 13350,              
                    NumberOfCrew = 12,             
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                                    // Flight for Apr 2025
                    Aircraft = aircrafts["VN50"],
                    OriginAirport = airports["HAN"],
                    DestinationAirport = airports["MAD"],
                    DepartureTime = new DateTime(2025, 4, 10, 23, 30, 0), 
                    ArrivalTime = new DateTime(2025, 4, 11, 6, 15, 0),    
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 245,                
                    Distance = 10250,               
                    NumberOfCrew = 14,              
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                           // flightDetails[28]                                    
                    Aircraft = aircrafts["LX38"],                       // Flight for May 2025
                    OriginAirport = airports["CDG"],
                    DestinationAirport = airports["NRT"],
                    DepartureTime = new DateTime(2025, 5, 8, 12, 0, 0),
                    ArrivalTime = new DateTime(2025, 5, 9, 7, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 280,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 9715,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                           // flightDetails[29]                                      
                    Aircraft = aircrafts["IB6401"],                     // Flight for May 2025
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2025, 5, 17, 22, 30, 0),
                    ArrivalTime = new DateTime(2025, 5, 18, 6, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 18000,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                           // flightDetails[30]                                    
                    Aircraft = aircrafts["SQ12"],                       // Flight for Jun 2025
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2025, 6, 12, 11, 55, 0),
                    ArrivalTime = new DateTime(2025, 6, 12, 18, 5, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 10560,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                           // flightDetails[31]  
                    Aircraft = aircrafts["AF83"],                       // Flight for Jun 2025
                    OriginAirport = airports["FRA"],
                    DestinationAirport = airports["GRU"],
                    DepartureTime = new DateTime(2025, 6, 17, 16, 30, 0),
                    ArrivalTime = new DateTime(2025, 6, 17, 20, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 240,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 9350,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                           // flightDetails[32]                          
                    Aircraft = aircrafts["EY101"],                      // Flight for Jul 2025
                    OriginAirport = airports["AUH"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2025, 7, 19, 9, 30, 0),
                    ArrivalTime = new DateTime(2025, 7, 19, 14, 45, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 290,
                    OverbookingCount = 0,
                    SeatsSold = 310,
                    Distance = 4640,
                    NumberOfCrew = 14,
                    Prediction = null,
                    Probability = null
                  },

                   new FlightDetail {                           // flightDetails[33]         
                    Aircraft = aircrafts["AR1301"],                     // Flight for Jul 2025
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2025, 7, 7, 12, 0, 0),
                    ArrivalTime = new DateTime(2025, 7, 7, 18, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 235,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 13200,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[34]         
                    Aircraft = aircrafts["AR1324"],                     // Flight for Jul 2024
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["SIN"],
                    DepartureTime = new DateTime(2024, 7, 7, 12, 0, 0),
                    ArrivalTime = new DateTime(2024, 7, 7, 18, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 235,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 13200,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
                     new FlightDetail {                           // flightDetails[35]                                      
                    Aircraft = aircrafts["IB6424"],                     // Flight for Jun 2024
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2024, 6, 17, 22, 30, 0),
                    ArrivalTime = new DateTime(2024, 6, 18, 6, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 18000,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                      new FlightDetail {                           // flightDetails[36]                                    
                    Aircraft = aircrafts["SQ24"],                       // Flight for Aug 2024
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2024, 8, 12, 11, 55, 0),
                    ArrivalTime = new DateTime(2024, 8, 12, 18, 5, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 10560,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
                     new FlightDetail {                           // flightDetails[37]                          
                    Aircraft = aircrafts["EY123"],                      // Flight for Jul 2023
                    OriginAirport = airports["AUH"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2023, 7, 19, 9, 30, 0),
                    ArrivalTime = new DateTime(2023, 7, 19, 14, 45, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 290,
                    OverbookingCount = 0,
                    SeatsSold = 310,
                    Distance = 4640,
                    NumberOfCrew = 14,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[38]  
                    Aircraft = aircrafts["AF23"],                       // Flight for Jun 2023
                    OriginAirport = airports["FRA"],
                    DestinationAirport = airports["GRU"],
                    DepartureTime = new DateTime(2023, 6, 17, 16, 30, 0),
                    ArrivalTime = new DateTime(2023, 6, 17, 20, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 240,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 9350,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[39]                                    
                    Aircraft = aircrafts["SQ23"],                       // Flight for Jun 2023
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2023, 6, 12, 11, 55, 0),
                    ArrivalTime = new DateTime(2023, 6, 12, 18, 5, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 10560,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[40]                                      
                    Aircraft = aircrafts["IB6422"],                     // Flight for May 2022
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2022, 5, 17, 22, 30, 0),
                    ArrivalTime = new DateTime(2022, 5, 18, 6, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 18000,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[41]  
                    Aircraft = aircrafts["AF22"],                       // Flight for Jun 2022
                    OriginAirport = airports["FRA"],
                    DestinationAirport = airports["GRU"],
                    DepartureTime = new DateTime(2022, 6, 17, 16, 30, 0),
                    ArrivalTime = new DateTime(2022, 6, 17, 20, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 240,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 9350,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[42]                                    
                    Aircraft = aircrafts["SQ22"],                       // Flight for Jun 2022
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2022, 6, 12, 11, 55, 0),
                    ArrivalTime = new DateTime(2022, 6, 12, 18, 5, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 10560,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[43]                                      
                    Aircraft = aircrafts["IB6421"],                     // Flight for May 2021
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2021, 5, 17, 22, 30, 0),
                    ArrivalTime = new DateTime(2021, 5, 18, 6, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 18000,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[44]  
                    Aircraft = aircrafts["AF21"],                       // Flight for Jun 2021
                    OriginAirport = airports["FRA"],
                    DestinationAirport = airports["GRU"],
                    DepartureTime = new DateTime(2021, 6, 17, 16, 30, 0),
                    ArrivalTime = new DateTime(2021, 6, 17, 20, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 240,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 9350,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[45]                                    
                    Aircraft = aircrafts["SQ21"],                       // Flight for Jun 2021
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2021, 6, 12, 11, 55, 0),
                    ArrivalTime = new DateTime(2021, 6, 12, 18, 5, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 10560,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[46]                                      
                    Aircraft = aircrafts["IB6420"],                     // Flight for May 2020
                    OriginAirport = airports["EZE"],
                    DestinationAirport = airports["ICN"],
                    DepartureTime = new DateTime(2020, 5, 17, 22, 30, 0),
                    ArrivalTime = new DateTime(2020, 5, 18, 6, 15, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 230,
                    OverbookingCount = 0,
                    SeatsSold = 245,
                    Distance = 18000,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[47]  
                    Aircraft = aircrafts["AF20"],                       // Flight for Jun 2020
                    OriginAirport = airports["FRA"],
                    DestinationAirport = airports["GRU"],
                    DepartureTime = new DateTime(2020, 6, 17, 16, 30, 0),
                    ArrivalTime = new DateTime(2020, 6, 17, 20, 0, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 240,
                    OverbookingCount = 0,
                    SeatsSold = 250,
                    Distance = 9350,
                    NumberOfCrew = 18,
                    Prediction = null,
                    Probability = null
                  },
                    new FlightDetail {                           // flightDetails[48]                                    
                    Aircraft = aircrafts["SQ20"],                       // Flight for Jun 2020
                    OriginAirport = airports["KUL"],
                    DestinationAirport = airports["FRA"],
                    DepartureTime = new DateTime(2020, 6, 12, 11, 55, 0),
                    ArrivalTime = new DateTime(2020, 6, 12, 18, 5, 0),
                    IsHoliday = false,
                    FlightStatus = "Landed",
                    CheckInCount = 300,
                    OverbookingCount = 0,
                    SeatsSold = 320,
                    Distance = 10560,
                    NumberOfCrew = 16,
                    Prediction = null,
                    Probability = null
                  },
            };

                db.FlightDetails.AddRange(flightDetailList);
                db.SaveChanges();

                return Ok("Flight Details seeded successfully.");
        }
    }
}













