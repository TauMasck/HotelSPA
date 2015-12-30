using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Repository
{
    public class AccommodationRepository
    {
		/// <summary>
		/// The context.
		/// </summary>
        private ClientRepository _clientRepository;
        private RoomRepository _roomRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="RestApp.Repository.AccommodationRepository"/> class.
		/// </summary>
        public AccommodationRepository()
        {
            _clientRepository = new ClientRepository();
            _roomRepository = new RoomRepository();
        }

        public ClientViewModel AccommodateClient(AccommodationViewModel model)
        {
            ClientViewModel client = _clientRepository.Get(model.ClientId);
            client.RoomNumber = model.RoomId;

            _clientRepository.Update(client);
            _roomRepository.ChangeStatus(model.RoomId, false);

            return client;
        }
    }
}