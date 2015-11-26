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
    public class TreatmentsController : ApiController
    {
        private TreatmentRepository repository;

        public TreatmentsController() {
            this.repository = new TreatmentRepository();
        }

        // GET treatments
        public IEnumerable<TreatmentViewModel> Get()
        {
            // blad gdy null?
            return this.repository.GetAll();
        }

        // POST treatments 
        public HttpResponseMessage Post(TreatmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(model);

                var response = Request.CreateResponse<TreatmentViewModel>(HttpStatusCode.Created, model);

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
        //public HttpResponseMessage Put(int id, Treatment model)
        //{
        //    if (ModelState.IsValid && id == model.Id)
        //    {
        //        //tu jeszcze bym dodała try-catch na submit changes 
        //        //ew. osobna metoda, która by to robiła
        //        //ew.2 łapanie po różnych wyjątkach tak jak niżej jest
        //        try
        //        {
        //            repository.UpdateTreatmentById(id, model);
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
        public HttpResponseMessage Put(Guid id, bool active)
        {
            if (ModelState.IsValid)
            {
                var existingTreatment = this.repository.Get(id);

                if (existingTreatment == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                var treatment = this.repository.ChangeStatus(id, active);

                return Request.CreateResponse(HttpStatusCode.OK, treatment);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
