using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




    public static class RoomManager
    {
        public static IEnumerable<Room> GetAllRooms()
        {
            return DataManager.Rooms.OrderBy(r => r.RoomId);
        }

        public static void AddRoom(int roomId, RoomType type, bool available, string notes)
        {
            if (DataManager.Rooms.Any(r => r.RoomId == roomId))
                throw new Exception("Room already exists.");

            DataManager.Rooms.Add(new Room
            {
                RoomId = roomId,
                Type = type,
                IsAvailable = available,
                Notes = notes
            });
        }

        public static void UpdateRoom(int roomId, RoomType type, bool available, string notes)
        {
            var r = DataManager.Rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (r == null) throw new Exception("Room not found.");

            r.Type = type;
            r.IsAvailable = available;
            r.Notes = notes;
        }

        public static void DeleteRoom(int roomId)
        {
            var r = DataManager.Rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (r != null) DataManager.Rooms.Remove(r);
        }
    }
