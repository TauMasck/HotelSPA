using RestApp.Models;
using RestApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApp.Controllers
{
    /// <summary>
    /// Accommodation controller.
    /// </summary>
    [RoutePrefix("api/Accommodation/")]
    public class AccommodationController : ApiController
    {
        private AccommodationRepository _repository;
        private ClientRepository _clientRepository;
        private RoomRepository _roomRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestApp.Controllers.AccommodationController"/> class.
		/// </summary>
        public AccommodationController()
        {
            _repository = new AccommodationRepository();
            _clientRepository = new ClientRepository();
            _roomRepository = new RoomRepository();
        }

        #region POST
        // POST clients 
        /// <summary>
        /// Post the object with client's and room's id.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("")]
        public HttpResponseMessage Post(AccommodationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClientViewModel client = _clientRepository.Get(model.ClientId);

                if (client == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("Client not found")
                    });
                }

                RoomViewModel room = _roomRepository.Get(model.RoomId);

                if (room == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("Room not found")
                    });
                }
                else if (!room.Available)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Conflict,
                        Content = new StringContent("Room is not available.")
                    });
                }

                try
                {
                    client = _repository.AccommodateClient(model);
                }
                catch 
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("Something goes wrong.")
                    });
                }

                var response = Request.CreateResponse<ClientViewModel>(HttpStatusCode.Created, client);

                string uri = Url.Link("DefaultApi", new { id = model.ClientId });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion
    }
}
