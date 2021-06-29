using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static BookRoomViewModel ToViewModel(Room room){

            BookRoomViewModel model = new BookRoomViewModel();

            model.RoomId = room.RoomId;
            model.HotelId = room.HostleId;
            model.ClientId = room.UserId;
            

            return model;
        }
    }

    public class BookRoomDetailsViewModel : BookRoomViewModel
    {

        public int Total { get; set; }

        public static BookRoomDetailsViewModel ToViewModel(BookRoomViewModel model) {

            BookRoomDetailsViewModel ViewModel = new BookRoomDetailsViewModel();

            ViewModel.RoomId = model.RoomId;
            ViewModel.HotelId = model.HotelId;
            ViewModel.ClientId = model.ClientId;
            ViewModel.HotelName = model.HotelName;
            ViewModel.StartDate = model.StartDate;
            ViewModel.NumNights = model.NumNights;
            ViewModel.NumPeople = model.NumPeople;
            //  rest 

            return ViewModel;

        }
    }
}