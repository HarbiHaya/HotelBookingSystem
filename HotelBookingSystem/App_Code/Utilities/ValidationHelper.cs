using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public static class ValidationHelper
    {
        public static bool IsDateRangeValid(DateTime checkIn, DateTime checkOut)
        {
            return checkIn.Date < checkOut.Date;
        }

        public static bool IsFuture(DateTime date)
        {
            return date.Date >= DateTime.Today;
        }
    }
