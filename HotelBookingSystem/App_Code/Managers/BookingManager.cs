using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public static class BookingManager
    {
        public static Booking CreateBooking(
            string guestEmail,
            string guestName,
            string phone,
            int roomId,
            DateTime checkIn,
            DateTime checkOut,
            List<string> selectedServiceNames)
        {
            var room = DataManager.GetRoom(roomId);
            if (room == null || !room.IsAvailable)
                throw new Exception("Room not available.");

            if (!ValidationHelper.IsDateRangeValid(checkIn, checkOut))
                throw new Exception("Invalid date range.");

            decimal nightlyRate;
            var total = PricingEngine.CalculateTotal(
                room.Type,
                checkIn,
                checkOut,
                DateTime.Now,
                out nightlyRate
            );

            var services = DataManager.Services
                .Where(s => selectedServiceNames.Contains(s.Name))
                .ToList();

            var finalWithServices = total + services.Sum(s => s.Price);

            var booking = new Booking
            {
                GuestEmail = guestEmail,
                GuestName = guestName,
                Phone = phone,
                RoomId = room.RoomId,
                RoomType = room.Type,
                CheckIn = checkIn,
                CheckOut = checkOut,
                BasePricePerNight = nightlyRate,
                FinalPriceTotal = finalWithServices,
                Status = BookingStatus.Pending
            };

            DataManager.Bookings.Add(booking);
            return booking;
        }

        public static IEnumerable<Booking> GetBookingsForUser(string email)
        {
            return DataManager.Bookings
                .Where(b => b.GuestEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(b => b.CreatedAt);
        }

        public static IEnumerable<Booking> GetAllBookings()
        {
            return DataManager.Bookings
                .OrderByDescending(b => b.CreatedAt);
        }

        public static Booking GetBooking(Guid id)
        {
            return DataManager.Bookings.FirstOrDefault(b => b.BookingId == id);
        }

        public static void UpdateStatus(Guid bookingId, BookingStatus newStatus)
        {
            var b = GetBooking(bookingId);
            if (b != null) b.Status = newStatus;
        }

        public static void AddAdminComment(Guid bookingId, string comment)
        {
            var b = GetBooking(bookingId);
            if (b != null && !string.IsNullOrWhiteSpace(comment))
                b.AdminComments.Add($"{DateTime.Now}: {comment}");
        }

        public static decimal CancelBooking(Guid bookingId, out decimal penaltyApplied)
        {
            var b = GetBooking(bookingId);
            if (b == null) throw new Exception("Booking not found.");

            penaltyApplied = PricingEngine.CalculateCancellationPenalty(b, DateTime.Now);
            b.Status = BookingStatus.Cancelled;
            return penaltyApplied;
        }
    }
