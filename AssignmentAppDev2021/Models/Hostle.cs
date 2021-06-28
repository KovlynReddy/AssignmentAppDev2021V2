using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AssignmentAppDev2021.Models
{
    public class Hostle
    {
        public int Id { get; set; }
        public string HostleId { get; set; }
        public string LocationId { get; set; }
        public string HostleName { get; set; }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReservaationId { get; set; }
        public int Elapsed
        {
            get
            {
                if (DateTime.Now > EndDate || DateTime.Now < StartDate)
                {
                    return 1;
                }
                else if (DateTime.Now < EndDate && DateTime.Now > StartDate)
                {
                    return 2;
                }
                else { return 3; }
            }
        }
    }
    public class Room
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public string HostleId { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public string UserId { get; set; }
        public string BookingId { get; set; }
        public string ReservationId { get; set; }
        public int IsVacant { get; set; }
        public bool IsVacantBool
        {
            get
            {
                if (IsVacant == 1)
                {
                    return true;
                }
                else if (IsVacant > 1 ) {
                }
                return false;
            } 
        }

    }

    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BookingId { get; set; }
        public string Reservation { get; set; }
    }
    public interface IHostleRepository
    {
        //Task<Hostle> AddHostleAsync(Hostle newHostle);
        Hostle AddHostle(Hostle newHostle);
        //Task<Hostle> GetHostleAsync(Hostle hostle);
        //Task<Hostle> GetHostleAsync(string hostleId);
        //Hostle GetHostle(Hostle hostle);
        Hostle GetHostler(string hostleId);
        Task<Hostle> DeleteHostleAsync(string hostleId);
        //Task<List<Hostle>> GetAllHostlesAsync();
        List<Hostle> GetAllHostles();
    }

    public interface IRoomRepository
    {
        //Task<Room> AddRoomAsync(Room newRoom);
        Room AddRoom(Room newRoom);
        //Task<Room> GetRoomAsync(Room room);
        //Task<Room> GetHostleAsync(string roomId);
        //Room GetRoom(Room room);
        Room GetRoom(string roomId);
        //Task<Room> DeleteRoomAsync(string roomId);
        //Task<List<Room>> GetAllRoomsAsync();
        List<Room> GetAllRooms();
    }
    public interface IReservationRepository
    {
        //    Task<Reservation> AddReservationAsync(Reservation newReservation);
        Reservation AddReservation(Reservation newReservation);
        //    Task<Reservation> GetReservationAsync(Reservation reservation);
        //    Task<Reservation> GetReservationAsync(string reservationId);
        //    Reservation GetReservation(Reservation reservation);
        Reservation GetReservation(string reservationId);
        //    Task<Reservation> DeleteReservationAsync(string reservationId);
        //    Task<List<Reservation>> GetAllReservationAsync();
        List<Reservation> GetAllReservation();
    }
    public interface IBookingRepository
    {
        //    Task<Booking> AddBookingAsync(Booking newBooking);
        Booking AddBooking(Booking newBooking);
        //    Task<Booking> GetBookingAsync(Booking booking);
        //    Task<Booking> GetBookingAsync(string bookingId);
        //    Booking GetBooking(Booking booking);
        Booking GetBooking(string bookingId);
        //    Task<Booking> DeleteBookingAsync(string bookingId);
        //    Task<List<Booking>> GetAllBookingAsync();
        List<Booking> GetAllBooking();
    }

    public interface IUserRepository {
        string AddUser(string newUser);
        string GetUser(int index);
        List<string> GetAllUsers();  

        string AddCountry(string newCountry);
        string GetCountry(int index);
        List<string> GetAllContries();

    }

    public class MockDB : IHostleRepository, IBookingRepository, IReservationRepository, IRoomRepository , IUserRepository
    {
        public List<Hostle> hostles { get; set; } = new List<Hostle>();
        public List<Booking> bookings { get; set; } = new List<Booking>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<Room> rooms { get; set; } = new List<Room>();
        public List<string> countries { get; set; } = new List<string>();
        public List<string> users { get; set; }

        public void InitDb() { 
        hostles = new List<Hostle>{ new Hostle { Id = 1 , HostleId = $"HostleId1" , HostleName = $"Hostle1" , LocationId = "1"} ,
                                    new Hostle { Id = 2 , HostleId = $"HostleId2" , HostleName = $"Hostle2" , LocationId = "2"} ,
                                    new Hostle { Id = 3 , HostleId = $"HostleId3" , HostleName = $"Hostle3" , LocationId = "3"} ,
                                    new Hostle { Id = 4 , HostleId = $"HostleId4" , HostleName = $"Hostle4" , LocationId = "3"} 

                                  };

            bookings = new List<Booking>{ new Booking { Id = 1 , BookingId = "BookingId1", UserId = "UserId1", Reservation = "ReservationId1"  } ,
                                    new Booking { Id = 2 , BookingId = "BookingId2", UserId = "UserId2", Reservation = "ReservationId2"  } ,
                                    new Booking { Id = 3 , BookingId = "BookingId3", UserId = "UserId3", Reservation = "ReservationId3"  } ,
                                    new Booking { Id = 4 , BookingId = "BookingId4", UserId = "UserId4", Reservation = "ReservationId4"  } ,
                                    new Booking { Id = 5 , BookingId = "BookingId5", UserId = "UserId5", Reservation = "ReservationId5"  } ,
                                    new Booking { Id = 6 , BookingId = "BookingId6", UserId = "UserId6", Reservation = "ReservationId6"  } ,
                                    new Booking { Id = 7 , BookingId = "BookingId7", UserId = "UserId7", Reservation = "ReservationId17"  } ,
                                    new Booking { Id = 8 , BookingId = "BookingId8", UserId = "UserId8", Reservation = "ReservationId18"  } ,
                                    new Booking { Id = 9 , BookingId = "BookingId9", UserId = "UserId9", Reservation = "ReservationId19"  } ,
                                    new Booking { Id = 10 , BookingId = "BookingId10", UserId = "UserId10", Reservation = "ReservationId20"  } 

                                  };

            reservations = new List<Reservation>{ new Reservation { Id = 1 , StartDate = DateTime.Parse("02-02-2021"), EndDate = DateTime.Parse("03-05-2021"), ReservaationId = "ReservationId1" } ,
                                    new Reservation  { Id = 2 , StartDate =  DateTime.Parse("04-01-2021"), EndDate = DateTime.Parse("04-05-2021"), ReservaationId = "ReservationId2" } ,
                                    new Reservation  { Id = 3 , StartDate =  DateTime.Parse("04-01-2021"), EndDate = DateTime.Parse("04-09-2021"), ReservaationId = "ReservationId3" } ,
                                    new Reservation  { Id = 4 , StartDate =  DateTime.Parse("04-01-2021"), EndDate = DateTime.Parse("04-11-2021"), ReservaationId = "ReservationId4" } ,
                                    new Reservation  { Id = 5 , StartDate =  DateTime.Parse("04-01-2021"), EndDate = DateTime.Parse("04-15-2021"), ReservaationId = "ReservationId5" } ,
                                    new Reservation  { Id = 6 , StartDate =  DateTime.Parse("04-10-2021"), EndDate = DateTime.Parse("04-16-2021"), ReservaationId = "ReservationId6" } ,
                                    new Reservation  { Id = 7 , StartDate =  DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("05-10-2021"), ReservaationId = "ReservationId7" } ,
                                    new Reservation  { Id = 8 , StartDate =  DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("05-14-2021"), ReservaationId = "ReservationId8" } ,
                                    new Reservation  { Id = 9 , StartDate =  DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("05-15-2021"), ReservaationId = "ReservationId9" } ,
                                    new Reservation  { Id = 10 , StartDate = DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("05-27-2021"), ReservaationId = "ReservationId10" } ,
                                    new Reservation  { Id = 11 , StartDate = DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("05-28-2021"), ReservaationId = "ReservationId11" } ,
                                    new Reservation  { Id = 12 , StartDate = DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("05-26-2021"), ReservaationId = "ReservationId12" } ,
                                    new Reservation  { Id = 13 , StartDate = DateTime.Parse("05-10-2021"), EndDate = DateTime.Parse("06-10-2021"), ReservaationId = "ReservationId13" } ,
                                    new Reservation  { Id = 14 , StartDate = DateTime.Parse("06-10-2021"), EndDate = DateTime.Parse("06-15-2021"), ReservaationId = "ReservationId14" } ,
                                    new Reservation  { Id = 15 , StartDate = DateTime.Parse("06-10-2021"), EndDate = DateTime.Parse("06-16-2021"), ReservaationId = "ReservationId15" } ,
                                    new Reservation  { Id = 16 , StartDate = DateTime.Parse("06-01-2021"), EndDate = DateTime.Parse("06-16-2021"), ReservaationId = "ReservationId16" } ,
                                    new Reservation  { Id = 17 , StartDate = DateTime.Parse("06-01-2021"), EndDate = DateTime.Parse("06-17-2021"), ReservaationId = "ReservationId17" } ,
                                    new Reservation  { Id = 18 , StartDate = DateTime.Parse("06-01-2021"), EndDate = DateTime.Parse("06-20-2021"), ReservaationId = "ReservationId18" } ,
                                    new Reservation  { Id = 19 , StartDate = DateTime.Parse("06-01-2021"), EndDate = DateTime.Parse("07-21-2021"), ReservaationId = "ReservationId19" } ,
                                    new Reservation  { Id = 20 , StartDate = DateTime.Parse("07-05-2021"), EndDate = DateTime.Parse("07-15-2021"), ReservaationId = "ReservationId20" } ,
                                    new Reservation  { Id = 21 , StartDate = DateTime.Parse("07-05-2021"), EndDate = DateTime.Parse("07-18-2021"), ReservaationId = "ReservationId21" }
                                  };

            rooms = new List<Room>{ new Room { Id = 1 ,RoomId = "RoomId1", HostleId = "HostleId1" , BookingId = "BookingId1", Floor = 1 , ReservationId = "ReservationId1", RoomNumber = 1 , UserId = "UserId1"} ,
                                    new Room { Id = 2 ,RoomId = "RoomId2", HostleId = "HostleId2" , BookingId = "BookingId2", Floor = 1 , ReservationId = "ReservationId2", RoomNumber = 1 , UserId = "UserId2"} ,
                                    new Room { Id = 3 ,RoomId = "RoomId3", HostleId = "HostleId3" , BookingId = "BookingId3", Floor = 1 , ReservationId = "ReservationId3", RoomNumber = 1 , UserId = "UserId3"} ,
                                    new Room { Id = 4 ,RoomId = "RoomId4", HostleId = "HostleId4" , BookingId = "BookingId4", Floor = 1 , ReservationId = "ReservationId4", RoomNumber = 1 , UserId = "UserId4"} ,
                                    new Room { Id = 5 ,RoomId = "RoomId5", HostleId = "HostleId1" , BookingId = "BookingId5", Floor = 1 , ReservationId = "ReservationId5", RoomNumber = 2 , UserId = "UserId5"} ,
                                    new Room { Id = 6 ,RoomId = "RoomId6", HostleId = "HostleId2" , BookingId = "BookingId6", Floor = 1 , ReservationId = "ReservationId16", RoomNumber = 2 , UserId = "UserId6"} ,
                                    new Room { Id = 7 ,RoomId = "RoomId7", HostleId = "HostleId3" , BookingId = "BookingId7", Floor = 1 , ReservationId = "ReservationId11", RoomNumber = 2 , UserId = "UserId7"} ,
                                    new Room { Id = 8 ,RoomId = "RoomId8", HostleId = "HostleId4" , BookingId = "BookingId8", Floor = 1 , ReservationId = "ReservationId12", RoomNumber = 2 , UserId = "UserId8"} ,
                                    new Room { Id = 9 ,RoomId = "RoomId9", HostleId = "HostleId1" , BookingId = "BookingId9", Floor = 2 , ReservationId = "ReservationId13", RoomNumber = 1 , UserId = "UserId9"} ,
                                    new Room { Id = 10,RoomId = "RoomId10" , HostleId = "HostleId2" , BookingId = "BookingId10", Floor = 2, ReservationId = "ReservationId10", RoomNumber = 1 , UserId = "UserId10"} ,
                                    new Room { Id = 11,RoomId = "RoomId11" , HostleId = "HostleId3" , BookingId = "BookingId1", Floor = 2 , ReservationId = "ReservationId1", RoomNumber = 1 , UserId = "UserId1"} ,
                                    new Room { Id = 12,RoomId = "RoomId12" , HostleId = "HostleId4" , BookingId = "BookingId2", Floor = 2 , ReservationId = "ReservationId2", RoomNumber = 1 , UserId = "UserId2"} ,
                                    new Room { Id = 13,RoomId = "RoomId13" , HostleId = "HostleId1" , BookingId = "BookingId3", Floor = 2 , ReservationId = "ReservationId3", RoomNumber = 2 , UserId = "UserId3"} ,
                                    new Room { Id = 14,RoomId = "RoomId14" , HostleId = "HostleId2" , BookingId = "BookingId4", Floor = 2 , ReservationId = "ReservationId4", RoomNumber = 2 , UserId = "UserId4"} ,
                                    new Room { Id = 15,RoomId = "RoomId15" , HostleId = "HostleId3" , BookingId = "BookingId5", Floor = 2 , ReservationId = "ReservationId5", RoomNumber = 2 , UserId = "UserId5"} ,
                                    new Room { Id = 16,RoomId = "RoomId16" , HostleId = "HostleId4" , BookingId = "BookingId6", Floor = 2 , ReservationId = "ReservationId6", RoomNumber = 2 , UserId = "UserId6"} 

                                  };
           
            countries = new List<string>{ "South Africa",
                                            "UK" ,
                                            "USA"

                                  };      
            
            users = new List<string>{ "UserId1",
                                       "UserId2",
                                       "UserId3" ,
                                       "UserId4" ,
                                       "UserId5" ,
                                       "UserId6",
                                       "UserId7" ,
                                       "UserId8" ,
                                       "UserId9" ,
                                       "UserId10" 
                                  };
           



        }

        public Booking AddBooking(Booking newBooking)
        {
            bookings.Add(newBooking);

            return bookings.FirstOrDefault(m => m.BookingId == newBooking.BookingId);
        }

        public Hostle AddHostle(Hostle newHostle)
        {
            throw new NotImplementedException();
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            reservations.Add(newReservation);

            return reservations.FirstOrDefault(m => m.ReservaationId == newReservation.ReservaationId);
        }

        public Room AddRoom(Room newRoom)
        {
            throw new NotImplementedException();
        }

        public Task<Hostle> DeleteHostleAsync(string hostleId)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAllBooking()
        {
            return bookings;
        }

        public List<Hostle> GetAllHostles()
        {
            return hostles;
        }

        public List<Reservation> GetAllReservation()
        {
            return reservations;
        }

        public List<Room> GetAllRooms()
        {
            return rooms;
        }

        public Booking GetBooking(string bookingId)
        {
            return bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }

        public Hostle GetHostler(string hostleId)
        {
            return hostles.FirstOrDefault(b => b.HostleId == hostleId);
        }

        public Reservation GetReservation(string reservationId)
        {
            return reservations.FirstOrDefault(b => b.ReservaationId == reservationId);
        }

        public Room GetRoom(string roomId)
        {
            return rooms.FirstOrDefault(b => b.RoomId == roomId);
        }

        public string AddUser(string newUser)
        {
            users.Add(newUser);
            return users.FirstOrDefault(u => u == newUser);
        }

        public string GetUser(int index)
        {

            return users[index];
        }

        public List<string> GetAllUsers()
        {
            return users; ;
        }

        public string AddCountry(string newCountry)
        {
            users.Add(newCountry);
            return users.FirstOrDefault(u => u == newCountry);
        }

        public string GetCountry(int index)
        {
            return countries[index];
        }

        public List<string> GetAllContries()
        {
            return countries;
        }

        public Room UpdateRoom(Room updatedRoom) {

            var room = rooms.Where(r => r.RoomId == updatedRoom.RoomId).FirstOrDefault();
            rooms.Remove(room);
            rooms.Add(updatedRoom);

            return rooms.Where(r => r.RoomId == updatedRoom.RoomId).FirstOrDefault();
        }
    }
}