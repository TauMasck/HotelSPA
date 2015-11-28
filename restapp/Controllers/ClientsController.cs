using RestApp.Models;
using RestApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

// dokumentacja
// https://msdn.microsoft.com/pl-pl/library/b2s063f7(v=vs.120).aspx

namespace RestApp.Controllers
{
    public class ClientsController : ApiController
    {
        private ClientRepository repository;

        public ClientsController() {
            this.repository = new ClientRepository();
        }

        #region GET
        // GET clients
        // http://localhost:55534/api/clients
        public IEnumerable<ClientViewModel> Get()
        {
            return this.repository.GetAll();
        }

        // GET clients/{id}
        // http://localhost:55534/api/clients/29c30781-2df5-4fd5-83ed-0564a83fe7cd
        public ClientViewModel Get(Guid id)
        {
            ClientViewModel client = repository.Get(id);
 
            if (client == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Client not found")
                });
            }
            else
            {
                return client;
            }
        }
        #endregion

        #region POST
        // POST clients 
        public HttpResponseMessage Post(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(model);

                var response = Request.CreateResponse<ClientViewModel>(HttpStatusCode.Created, model);

                string uri = Url.Link("DefaultApi", new { id = model.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region PUT
        // PUT clients/{id}
        // PUT: czy powinna być możliwość zmiany pojedynczej właśności rekordu, czy zawsze cały obiekt będzie wysyłany?
        public Clients Put(Guid id, ClientViewModel model)
        {
            model.Id = id;
            Console.WriteLine(model);
            //dodać obsługę błędu dla pustego obiektu

            var existingClient = this.repository.Get(model.Id);

            if(existingClient == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return this.repository.Update(model);
        }
        #endregion

        #region DELETE
        // DELETE clients/{id}
        public HttpResponseMessage Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                var existingClient = this.repository.Get(id);

                if (existingClient == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                var client = this.repository.Delete(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
                //return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion
        
    }
}
