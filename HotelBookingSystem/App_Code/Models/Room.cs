using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Room
    {
        public int RoomId { get; set; }
        public RoomType Type { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Notes { get; set; } // maintenance notes etc.
    }
