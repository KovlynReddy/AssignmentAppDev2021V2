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
            var room = _Db.GetAllRooms().FirstOrDefault(m => m.RoomId == model.RoomId);

            var hotel = _Db.GetAllHostles().FirstOrDefault(m => m.HostleId == room.HostleId);

            var AllReservations = _Db.GetAllReservation();
            var lastReservation = AllReservations.FirstOrDefault(r => r.ReservaationId == room.ReservationId);
            int Total = 0;
            if (lastReservation.EndDate < DateTime.Today)
            {
                // you can book 
                // change room details 
                // Add Username to Rooom
                room.UserId = User.Identity.Name;
                Reservation newReservation = new Reservation();
                newReservation.ReservaationId = Guid.NewGuid().ToString();
                newReservation.StartDate = model.StartDate;
                newReservation.EndDate = newReservation.StartDate.AddDays(model.NumNights);


                Booking newBooking = new Booking();
                newBooking.Reservation = newReservation.ReservaationId;
                newBooking.UserId = User.Identity.Name;
                newBooking.BookingId = Guid.NewGuid().ToString();

                newBooking.Total = model.NumPeople * model.NumNights * (model.BoolLuxary ? 21 : 25) * (model.BoolDiscount ? 1 : 2); //math ;
                Total = newBooking.Total;
                room.BookingId = newBooking.BookingId;
                room.ReservationId = newReservation.ReservaationId;
                room.UserId = User.Identity.Name;

                _Db.AddBooking(newBooking);
                _Db.AddReservation(newReservation);
                _Db.UpdateRoom(room);
            }

            // you cant book 




            ViewRoomsViewModel roomviewmodel = new ViewRoomsViewModel();

            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.Locations = _Db.GetAllContries();
            roomviewmodel.Hotels = _Db.GetAllHostles();
            roomviewmodel.Rooms = _Db.GetAllRooms();
            roomviewmodel.Users = _Db.GetAllUsers();
            roomviewmodel.bookings = _Db.GetAllBooking();
            roomviewmodel.reservations = _Db.GetAllReservation();

            foreach (var Aroom in roomviewmodel.Rooms)
            {
                var reservation = roomviewmodel.reservations.FirstOrDefault(m => m.ReservaationId == Aroom.ReservationId);
                Aroom.IsVacant = reservation.Elapsed;

            }

            //return View("TestViewRooms", roomviewmodel);

            var Amodel = BookRoomViewModel.ToViewModel(room);



            //BookRoomViewModel CurrentBooking = new BookRoomViewModel();


            BookRoomDetailsViewModel CurrentBookingView = BookRoomDetailsViewModel.ToViewModel(Amodel);
            //var mybooking = _Db.GetAllBooking().FirstOrDefault(m => m.BookingId == room.BookingId);
            CurrentBookingView.Total = Total;
            // view Details 
            return View("ViewBookingDetails", CurrentBookingView);
        


            //return View("TestingBooking", Amodel);

        }   
        
        [HttpGet]
        public ActionResult BookARoom(string id) {
            //
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
           
            var model = BookRoomViewModel.ToViewModel(room);


            if (room.UserId == UserName)
            {
                //BookRoomViewModel CurrentBooking = new BookRoomViewModel();


                BookRoomDetailsViewModel CurrentBookingView = (BookRoomDetailsViewModel)model;
                var mybooking = _Db.GetAllBooking().FirstOrDefault(m => m.BookingId == room.BookingId);
                CurrentBookingView.Total = mybooking.Total;
                // view Details 
                return View("ViewBookingDetails", CurrentBookingView);
            }


            return View("TestingBooking",model );
        }
    }
}