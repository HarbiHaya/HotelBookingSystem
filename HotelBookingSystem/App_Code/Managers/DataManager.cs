using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




    public static class DataManager
    {
        public static List<User> Users = new List<User>();
        public static List<Room> Rooms = new List<Room>();
        public static List<Booking> Bookings = new List<Booking>();
        public static List<Service> Services = new List<Service>();
        public static List<Notification> Notifications = new List<Notification>();

        static DataManager()
        {
            // Seed users
            Users.Add(new User
            {
                Email = "admin@hotel.com",
                Password = "Admin123",
                FullName = "System Admin",
                Role = UserRole.Admin
            });

            Users.Add(new User
            {
                Email = "halharbi0568@stu.kau.edu.sa",
                Password = "Haya123",
                FullName = "Haya Alharbi",
                Role = UserRole.Guest
            });
            Users.Add(new User
            {
                Email = "jalharbi0143@stu.kau.edu.sa",
                Password = "Jana123",
                FullName = "Jana Alharbi",
                Role = UserRole.Guest
            });
            Users.Add(new User
            {
                Email = "mmahfouz0007@stu.kau.edu.sa",
                Password = "Mayar123",
                FullName = "Mayar Mahfouz",
                Role = UserRole.Guest
            });
            Users.Add(new User
            {
                Email = "salamoudi0191@stu.kau.edu.sa",
                Password = "Shahad1",
                FullName = "Shahad Alamoudi",
                Role = UserRole.Guest
            });
            Users.Add(new User
            {
                Email = "salsubhi0115@stu.kau.edu.sa",
                Password = "Shahad2",
                FullName = "Shahad Abdullah",
                Role = UserRole.Guest
            });

            // Seed rooms
            Rooms.Add(new Room { RoomId = 101, Type = RoomType.Standard, IsAvailable = true });
            Rooms.Add(new Room { RoomId = 102, Type = RoomType.Standard, IsAvailable = true });
            Rooms.Add(new Room { RoomId = 201, Type = RoomType.Deluxe, IsAvailable = true });
            Rooms.Add(new Room { RoomId = 301, Type = RoomType.Suite, IsAvailable = true });

            // Seed services
            Services.Add(new Service { Name = "Airport Pickup", Price = 150m });
            Services.Add(new Service { Name = "Breakfast Buffet", Price = 70m });
            Services.Add(new Service { Name = "Spa Access", Price = 200m });
        }

        public static User GetUser(string email, string password)
        {
            return Users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password
            );
        }

        public static User GetUserByEmail(string email)
        {
            return Users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public static Room GetRoom(int roomId)
        {
            return Rooms.FirstOrDefault(r => r.RoomId == roomId);
        }
    } 
