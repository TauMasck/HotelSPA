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
	/// Treatments controller class.
	/// </summary>
    public class TreatmentsController : ApiController
    {
		
        private TreatmentRepository repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="RestApp.Controllers.TreatmentsController"/> class.
		/// </summary>
        public TreatmentsController() {
            this.repository = new TreatmentRepository();
        }

        #region GET
        // GET treatments
		/// <summary>
		/// Get all treatments.
		/// </summary>
        public IEnumerable<TreatmentViewModel> Get()
        {
            return this.repository.GetAll();
        }
        #endregion

        #region POST
        // POST treatments 
		/// <summary>
		/// Post the treatment according to specified model.
		/// </summary>
		/// <param name="model">Model.</param>
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
        #endregion

        #region PUT
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

        /*
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
        */
        #endregion
    }
}
