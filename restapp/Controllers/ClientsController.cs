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

        // GET clients
        public IEnumerable<Client> Get()
        {
            // blad gdy null?
            return this.repository.GetClients();
        }

        // GET clients/{id}
        public Client Get(int id)
        {
            Client client = repository.GetClientById(id);
 
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

        // POST clients 
        public HttpResponseMessage Post(Client model)
        {
            if (ModelState.IsValid)
            {
                //try-catch
                this.repository.SaveClient(model);
                //Clients client = repository.CreateClient(model);

                var response = Request.CreateResponse<Client>(HttpStatusCode.Created, model);

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
        public HttpResponseMessage Put(int id, Client model)
        {
            if (ModelState.IsValid && id == model.Id)
            {
                //tu jeszcze bym dodała try-catch na submit changes 
                //ew. osobna metoda, która by to robiła
                //ew.2 łapanie po różnych wyjątkach tak jak niżej jest
                try
                {
                    repository.UpdateClientById(id, model);
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

        // DELETE clients/{id}
        public HttpResponseMessage Delete(int id)
        {
            // tu tak samo
            try
            {
                var client = repository.DeleteClientById(id);

                return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            catch (System.InvalidOperationException)
            {
               return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }
        
    }
}
