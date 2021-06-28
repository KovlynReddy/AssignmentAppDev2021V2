﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentAppDev2021.Models
{
    public class BookRoomViewModel
    {
        public string RoomId { get; set; }
        public string HotelId { get; set; }
        public string ClientId { get; set; }
        public string HotelName { get; set; }
        public int Luxary { get; set; }
        public bool BoolLuxary { get; set; }
        public int NumNights { get; set; }
        public int NumPeople { get; set; }
        public int Discount { get; set; }
        public bool BoolDiscount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static BookRoomViewModel ToViewModel(Room room){

            BookRoomViewModel model = new BookRoomViewModel();

            model.RoomId = room.RoomId;

            return model;
        }
    }
}