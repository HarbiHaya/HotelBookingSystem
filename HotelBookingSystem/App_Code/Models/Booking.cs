using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Booking
    {
        public Guid BookingId { get; set; } = Guid.NewGuid();

        public string GuestEmail { get; set; }
        public string GuestName { get; set; }
        public string Phone { get; set; }

        public int RoomId { get; set; }
        public RoomType RoomType { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public decimal BasePricePerNight { get; set; }
        public decimal FinalPriceTotal { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public List<Service> SelectedServices { get; set; } = new List<Service>();

        // Admin notes / comments
        public List<string> AdminComments { get; set; } = new List<string>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
