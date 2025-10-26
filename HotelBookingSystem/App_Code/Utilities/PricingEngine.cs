using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public static class PricingEngine
    {
        public static decimal GetBaseRate(RoomType type)
        {
            switch (type)
            {
                case RoomType.Standard: return 100m;
                case RoomType.Deluxe: return 200m;
                case RoomType.Suite: return 350m;
                default: return 100m;
            }
        }

        public static decimal CalculateTotal(
            RoomType roomType,
            DateTime checkIn,
            DateTime checkOut,
            DateTime bookingCreatedAt,
            out decimal nightlyRateApplied)
        {
            decimal baseRate = GetBaseRate(roomType);

            // seasonality example (simple: June-Aug = peak +50%, Dec-Jan low? you can edit)
            bool isPeak = (checkIn.Month >= 6 && checkIn.Month <= 8);
            bool isOffPeak = (checkIn.Month == 2 || checkIn.Month == 3);

            if (isPeak)
                baseRate *= 1.50m;      // +50%
            else if (isOffPeak)
                baseRate *= 0.80m;      // -20%

            int nights = (checkOut.Date - checkIn.Date).Days;
            if (nights < 1) nights = 1;

            // length of stay discounts
            if (nights >= 30)
                baseRate *= 0.75m;      // -25%
            else if (nights >= 7)
                baseRate *= 0.85m;      // -15%

            // early bird (book >=30 days in advance)
            double advanceDays = (checkIn.Date - bookingCreatedAt.Date).TotalDays;
            if (advanceDays >= 30)
                baseRate *= 0.90m;      // -10%

            // last minute deal (within 48h)
            if (advanceDays <= 2)
                baseRate *= 0.70m;      // -30%

            nightlyRateApplied = Math.Round(baseRate, 2);
            return nightlyRateApplied * nights;
        }

        public static decimal CalculateCancellationPenalty(Booking booking, DateTime cancelTime)
        {
            var hoursPassed = (cancelTime - booking.CreatedAt).TotalHours;

            if (hoursPassed <= 24)
                return 0m; // free
            if (hoursPassed <= 48)
                return booking.FinalPriceTotal * 0.5m; // 50%
            return booking.FinalPriceTotal; // 100%
        }
    }

