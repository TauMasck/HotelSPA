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
	/// Rooms controller class.
	/// </summary>
    [Authorize]
    [RoutePrefix("api/Rooms/")]
    public class RoomsController : ApiController
    {
        private RoomRepository repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="RestApp.Controllers.RoomsController"/> class.
		/// </summary>
        public RoomsController() {
            this.repository = new RoomRepository();
        }

        // GET rooms
        /// <summary>
        /// Get all rooms.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("")]
        public IEnumerable<RoomViewModel> Get()
        {
            return this.repository.GetAll();
        }

        // POST rooms 
        /// <summary>
        /// Post the room according to specified model.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("")]
        public HttpResponseMessage Post(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(model);

                var response = Request.CreateResponse<RoomViewModel>(HttpStatusCode.Created, model);

                string uri = Url.Link("DefaultApi", new { id = model.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            } 
        }

        // PUT clients/{id}
        //public HttpResponseMessage Put(int id, Room model)
        //{
        //    if (ModelState.IsValid && id == model.Id)
        //    {
        //        //tu jeszcze bym dodała try-catch na submit changes 
        //        //ew. osobna metoda, która by to robiła
        //        //ew.2 łapanie po różnych wyjątkach tak jak niżej jest
        //        try
        //        {
        //            repository.UpdateRoomById(id, model);
        //        }

        //        catch (Exception ex)
        //        {
        //            //Console.WriteLine(ex.ToString());
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}


        // PUT clients/{id}
        /// <summary>
        /// Put the room with specified id and changes its status.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="active">If set to <c>true</c> active.</param>
        [Route("")]
        public HttpResponseMessage Put(Guid id, bool active)
        {
            if (ModelState.IsValid)
            {
                var existingRoom = this.repository.Get(id);

                if (existingRoom == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                
                var room = this.repository.ChangeStatus(id, active);
     
                return Request.CreateResponse(HttpStatusCode.OK, room);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
