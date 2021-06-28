using AssignmentAppDev2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AssignmentAppDev2021.Controllers
{
    public class HomeController : Controller
    {
        MockDB _Db = new MockDB();
        public HomeController()
        {
            _Db = new MockDB();
            _Db.InitDb();

        }

        public ActionResult Index()
        {
            ViewRoomsViewModel roomviewmodel = new ViewRoomsViewModel();

            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.Locations = _Db.GetAllContries();
            roomviewmodel.Hotels = _Db.GetAllHostles();
            roomviewmodel.Rooms = _Db.GetAllRooms();
            roomviewmodel.Users = _Db.GetAllUsers();
            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.reservations = _Db.GetAllReservation();

            foreach (var room in roomviewmodel.Rooms)
            {
                var reservation = roomviewmodel.reservations.FirstOrDefault(m => m.ReservaationId == room.ReservationId);
                room.IsVacant = reservation.Elapsed;

            }

            return View("TestViewRooms",roomviewmodel);

        }

        [HttpGet]
        public ActionResult TestViewRooms() {

            ViewRoomsViewModel roomviewmodel = new ViewRoomsViewModel();

            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.Locations = _Db.GetAllContries();
            roomviewmodel.Hotels = _Db.GetAllHostles();
            roomviewmodel.Rooms = _Db.GetAllRooms();
            roomviewmodel.Users = _Db.GetAllUsers();
            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.reservations = _Db.GetAllReservation();

            foreach (var room in roomviewmodel.Rooms)
            {
                var reservation = roomviewmodel.reservations.FirstOrDefault(m => m.ReservaationId == room.ReservationId);
                room.IsVacant = reservation.Elapsed;

            }

            return View(roomviewmodel);
        }

        public ActionResult BookRoom(string id) {

            var Room = _Db.GetRoom(id);

            if (!Room.IsVacantBool)
            {
                Room.UserId = User.Identity.Name;

                Booking newBooking = new Booking();
                newBooking.BookingId = Guid.NewGuid().ToString();
                newBooking.UserId = Room.UserId;

                Reservation newReservation = new Reservation();
                newReservation.StartDate = DateTime.Now;
                newReservation.EndDate = DateTime.Now.AddDays(2);
                newReservation.ReservaationId = Guid.NewGuid().ToString();

                Room.ReservationId = newReservation.ReservaationId;
                newBooking.Reservation = newReservation.ReservaationId;

                if (_Db.users.Contains(User.Identity.Name))
                {

                    _Db.AddUser(Room.UserId);
                }

                _Db.AddBooking(newBooking);
                _Db.AddReservation(newReservation);
                _Db.UpdateRoom(Room);
            }

            ViewRoomsViewModel roomviewmodel = new ViewRoomsViewModel();

            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.Locations = _Db.GetAllContries();
            roomviewmodel.Hotels = _Db.GetAllHostles();
            roomviewmodel.Rooms = _Db.GetAllRooms();
            roomviewmodel.Users = _Db.GetAllUsers();
            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.reservations = _Db.GetAllReservation();

            foreach (var room in roomviewmodel.Rooms)
            {
                var reservation = roomviewmodel.reservations.FirstOrDefault(m => m.ReservaationId == room.ReservationId);
                room.IsVacant = reservation.Elapsed;

            }


            return View("TestViewRooms", roomviewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult BookARoom(BookRoomViewModel model) {

            // create booking

            return View();
        }   
        
        [HttpGet]
        public ActionResult BookARoom(string id) {

            // get room
            Room room = new Room();
            room = _Db.GetAllRooms().FirstOrDefault(m => m.Id.ToString() == id);
            // get user
            string UserName = User.Identity.Name;
            Booking newBooking = new Booking();
            // make reservation 
            Reservation newReservation = new Reservation();
            newReservation.ReservaationId = Guid.NewGuid().ToString();
            newBooking.Reservation = newReservation.ReservaationId; 
            // book room 
            room.ReservationId = newReservation.ReservaationId;
            room.BookingId = newBooking.BookingId;

            var model = BookRoomViewModel.ToViewModel(new Room { RoomId = id });

            return View("TestingBooking",model );
        }
    }
}