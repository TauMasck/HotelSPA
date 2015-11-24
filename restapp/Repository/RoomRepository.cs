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

        public IEnumerable<RoomViewModel> GetRooms()
        {
            List<RoomViewModel> Rooms = new List<RoomViewModel>();

            var rooms = context.Rooms.Select(t => t).ToList();
            foreach (var data in rooms)
            {
                Rooms.Add(new RoomViewModel()
                {
                    Id = data.Id,
                    HowManyPerson = data.How_many_persons,
                    Price = data.Price,
                    Available = data.Available == 1 ? true : false,
                    Size = data.Size
                });
            }
            return Rooms;
        }

        public void SaveRoom(RoomViewModel model)
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


        // nie wiem czy potrzebne
        public void UpdateRoomById(int id, RoomViewModel model)
        {
            var room = context.Rooms.Single(x => x.Id == id);
            room.Size = model.Size;
            room.Available = model.Available ? 1 : 0;
            room.How_many_persons = model.HowManyPerson;
            room.Price = model.Price;
            context.SubmitChanges();
        }

        public void ChangeRoomStatusById(int id, bool active)
        {
            var room = context.Rooms.Single(x => x.Id == id);
            room.Available = active ? 1 : 0;
            context.SubmitChanges();
        }
    }
}