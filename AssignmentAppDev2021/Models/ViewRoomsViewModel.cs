using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentAppDev2021.Models
{
    public class ViewRoomsViewModel
    {
        public List<Hostle> Hotels { get; set; }
        public List<Room> Rooms { get; set; }
        public List<string> Locations { get; set; }
        public List<string> Users { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Reservation> reservations { get; set; }

    }
}