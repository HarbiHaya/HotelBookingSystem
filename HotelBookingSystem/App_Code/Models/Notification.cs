using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Notification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ToEmail { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
    }
