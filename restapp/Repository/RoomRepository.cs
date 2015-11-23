using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Repository
{
    public class RoomRepository
    {
        private HotelSPADataContext context;

        public RoomRepository()
        {
            context = new HotelSPADataContext();
        }

        public IEnumerable<Room> GetRooms()
        {
            List<Room> Rooms = new List<Room>();

            var rooms = context.Rooms.Select(t => t).ToList();
            foreach (var data in rooms)
            {
                Rooms.Add(new Room()
                {
                    Id = data.Id,
                    HowManyPerson = data.How_many_persons,
                    Price = (float)data.Price,
                    Available = data.Available == 1 ? true : false,
                    Size = (float)data.Size
                });
            }
            return Rooms;
        }

        public void SaveRoom(Room model)
        {
            Rooms room = new Rooms()
            {
                Size = model.Size,
                Available = model.Available ? 1 : 0,
                How_many_persons = model.HowManyPerson,
                Price = model.Price
            };

            context.Rooms.InsertOnSubmit(room);
            context.SubmitChanges();
        }


        public void UpdateRoomById(int id, Room model)
        {
            var room = context.Rooms.Single(x => x.Id == id);
            room.Size = model.Size;
            room.Available = model.Available ? 1 : 0;
            room.How_many_persons = model.HowManyPerson;
            room.Price = model.Price;
            context.SubmitChanges();
        }

        // nie wiem czy potrzebne
        public void DisableRoomById(int id, bool active)
        {
            var room = context.Rooms.Single(x => x.Id == id);
            room.Available = active ? 1 : 0;
            context.SubmitChanges();
        }
    }
}