using RestApp.Models;
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
        private HotelSPADataContext context;

        public ClientsController()
        {
            context = new HotelSPADataContext();
        }

        // GET clients
        public IEnumerable<Client> Get()
        {
            List<Client> Clients = new List<Client>();

            var query = from client in context.Clients
                        select client;
            var clients = query.ToList();
            foreach (var data in clients)
            {
                Clients.Add(new Client()
                {
                    Id = data.Id,
                    NameSurname = data.Name_surname,
                    IdNumber = data.Id_number,
                    Company = data.Company,
                    RoomNumber = data.Room_number,
                    IsHere = data.Is_here == 0 ? false : true,
                    Vegetarian = data.Vegetarian == 0 ? false : true,
                    Questionnaire = data.Questionnaire == 0 ? false : true,
                    Invoice = data.Invoice == 0 ? false : true
                });
            }
            return Clients;
        }

        // GET clients/{id}
        public Client Get(int id)
        {
            Client client = context.Clients.Where(x => x.Id == id)
                .Select(x => new Client() {
                    Id = x.Id,
                    NameSurname = x.Name_surname,
                    IdNumber = x.Id_number,
                    Company = x.Company,
                    RoomNumber = x.Room_number,
                    IsHere = x.Is_here == 0 ? false : true,
                    Vegetarian = x.Vegetarian == 0 ? false : true,
                    Questionnaire = x.Questionnaire == 0 ? false : true,
                    Invoice = x.Invoice == 0 ? false : true
                }).SingleOrDefault();
 
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
                Clients client = new Clients()
                {
                    Id = model.Id,
                    Name_surname = model.NameSurname,
                    Id_number = model.IdNumber,
                    Company = model.Company,
                    Room_number = model.RoomNumber,
                    Is_here = model.IsHere ? 0 : 1,
                    Vegetarian = model.Vegetarian ? 0 : 1,
                    Questionnaire = model.Questionnaire ? 0 : 1,
                    Invoice = model.Invoice ? 0 : 1,
                };

                context.Clients.InsertOnSubmit(client);
                context.SubmitChanges();

                var response = Request.CreateResponse(HttpStatusCode.Created, client);

                string uri = Url.Link("DefaultApi", new { id = client.Id });
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
                    var client = context.Clients.Single(x => x.Id == id);
                    client.Name_surname = model.NameSurname;
                    client.Id_number = model.IdNumber;
                    client.Company = model.Company;
                    client.Room_number = model.RoomNumber;
                    client.Is_here = model.IsHere ? 0 : 1;
                    client.Vegetarian = model.Vegetarian ? 0 : 1;
                    client.Questionnaire = model.Questionnaire ? 0 : 1;
                    client.Invoice = model.Invoice ? 0 : 1;
                    context.SubmitChanges();
                }

                catch
                {
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
                var client = context.Clients.Single(x => x.Id == id);
                context.Clients.DeleteOnSubmit(client);
                context.SubmitChanges();

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
