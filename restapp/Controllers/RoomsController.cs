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
    public class RoomsController : ApiController
    {
        private RoomRepository repository;

        public RoomsController() {
            this.repository = new RoomRepository();
        }

        // GET rooms
        public IEnumerable<RoomViewModel> Get()
        {
            // blad gdy null?
            return this.repository.GetRooms();
        }

        // POST rooms 
        public HttpResponseMessage Post(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                //try-catch
                this.repository.SaveRoom(model);
                //Rooms room = repository.CreateRoom(model);

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
        public HttpResponseMessage Put(int id, bool active)
        {
            if (ModelState.IsValid)
            {
                //tu jeszcze bym dodała try-catch na submit changes 
                //ew. osobna metoda, która by to robiła
                //ew.2 łapanie po różnych wyjątkach tak jak niżej jest
                try
                {
                    repository.ChangeRoomStatusById(id, active);
                }

                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
