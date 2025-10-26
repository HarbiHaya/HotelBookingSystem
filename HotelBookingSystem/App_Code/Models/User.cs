using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; } // plain for demo
        public string FullName { get; set; }
        public UserRole Role { get; set; }
    }
