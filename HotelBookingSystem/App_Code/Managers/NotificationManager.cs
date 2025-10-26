using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



    public static class NotificationManager
    {
        public static void SendNotification(string toEmail, string message)
        {
            DataManager.Notifications.Add(new Notification
            {
                ToEmail = toEmail,
                Message = message,
                SentAt = DateTime.Now
            });

            // In real life you'd send email here (SMTP)
        }

        public static IQueryable<Notification> GetForUser(string email)
        {
            return DataManager.Notifications
                .Where(n => n.ToEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(n => n.SentAt)
                .AsQueryable();
        }
    }
