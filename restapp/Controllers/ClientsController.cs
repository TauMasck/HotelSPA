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
using System.ServiceModel;
using System.ServiceModel.Web;

// dokumentacja
// https://msdn.microsoft.com/pl-pl/library/b2s063f7(v=vs.120).aspx

namespace RestApp.Controllers
{
    public class ClientsController : ApiController
    {
        private ClientRepository _repository;

        public ClientsController() {
            this._repository = new ClientRepository();
        }

        #region GET
        // GET clients
        // http://localhost:55534/api/clients
        [HttpGet]
        public IEnumerable<ClientViewModel> Get()
        {
            return _repository.GetAll();
        }

        // GET clients/{id}
        // http://localhost:55534/api/Clients/{id}/getbyid
        [HttpGet, ActionName("getById")]
        public ClientViewModel Get(Guid id)
        {
            ClientViewModel client = _repository.Get(id);
 
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

        //http://localhost:55534/api/Clients/{id}/gettreatments
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [ActionName("getTreatments")]
        public IEnumerable<ClientHistoryViewModel> GetTreatments(Guid id) 
        {
            ClientViewModel client = _repository.Get(id);

            if (client == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Client not found")
                });
            }
            return _repository.GetTreatmentsHistory(id);//"udało się pobrać";
        }


        #endregion

        #region POST
        // POST clients 
        public HttpResponseMessage Post(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClientViewModel client;
                try
                {
                     client = _repository.Add(model);
                }
                catch (NullReferenceException)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("Can't add undefined object")
                    });
                }

                var response = Request.CreateResponse<ClientViewModel>(HttpStatusCode.Created, client);

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
        public ClientViewModel Put(Guid id, ClientViewModel model)
        {
            CheckIfClientExist(id);

            model.Id = id;
            return _repository.Update(model);
        }


        [HttpPut, ActionName("putQuest")]
        public Clients PutQuest(Guid id, ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = CheckIfClientExist(id);

                try
                {
                    client.Questionnaire = model.Questionnaire;
                }
                catch (NullReferenceException)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("Can't change when option 'Questionnaire' is empty.")
                    });
                }
                return _repository.ChangeQuestStatus(id, model.Questionnaire);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut, ActionName("putVeg")]
        public ClientViewModel PutVeg(Guid id, ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = CheckIfClientExist(id);

                try
                {
                    client.Vegetarian = model.Vegetarian;
                }
                catch (NullReferenceException) 
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("Can't change when option 'Vegetarian' is empty.")
                    });
                }
                return _repository.Update(client);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region DELETE
        // DELETE clients/{id}
        public HttpResponseMessage Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                var existingClient = _repository.Get(id);

                if (existingClient == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                var client = _repository.Delete(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
                //return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        private ClientViewModel CheckIfClientExist(Guid id)
        {
            var client = _repository.Get(id);
            if (client == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Client not found.")
                });
            }
            return client;
        }
    }
}
