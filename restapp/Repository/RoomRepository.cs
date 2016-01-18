using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Repository
{
	/// <summary>
	/// Room repository class.
	/// </summary>
    public class RoomRepository
    {
        private HotelSPAEntities context;
		/// <summary>
		/// Initializes a new instance of the <see cref="RestApp.Repository.RoomRepository"/> class.
		/// </summary>
        public RoomRepository()
        {
            context = new HotelSPAEntities();
        }

		/// <summary>
		/// Gets all room.
		/// </summary>
		/// <returns>All rooms.</returns>
        public IEnumerable<RoomViewModel> GetAll()
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

		/// <summary>
		/// Get the room with specified id.
		/// </summary>
		/// <param name="id">Identifier.</param>
        public RoomViewModel Get(Guid id)
        {
            return context.Rooms.Where(x => x.Id == id)
                .Select(x => new RoomViewModel()
                {
                    Id = x.Id,
                    HowManyPerson = x.How_many_persons,
                    Price = x.Price,
                    Available = x.Available == 1 ? true : false,
                    Size = x.Size
                }).SingleOrDefault();
        }

		/// <summary>
		/// Add the specified room.
		/// </summary>
		/// <param name="model">Model.</param>
        public void Add(RoomViewModel model)
        {
            Rooms room = new Rooms()
            {
                Size = model.Size,
                Available = model.Available ? 1 : 0,
                How_many_persons = model.HowManyPerson,
                Price = model.Price
            };

            context.Rooms.Add(room);
            context.SaveChanges();
        }

        // nie wiem czy potrzebne
		/// <summary>
		/// Update the room with specified id.
		/// </summary>
		/// <param name="model">Model.</param>
        public void Update(RoomViewModel model)
        {
            var room = context.Rooms.Single(x => x.Id == model.Id);
            room.Size = model.Size;
            room.Available = model.Available ? 1 : 0;
            room.How_many_persons = model.HowManyPerson;
            room.Price = model.Price;
            context.SaveChanges();
        }

		/// <summary>
		/// Changes the status of specified room.
		/// </summary>
		/// <returns>The status.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="active">If set to <c>true</c> active.</param>
        public Rooms ChangeStatus(Guid id, bool active)
        {
            var room = context.Rooms.Single(x => x.Id == id);
            room.Available = active ? 1 : 0;
            context.SaveChanges();
            return room;
        }
    }
}