using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Repository
{
	/// <summary>
	/// Treatment repository class.
	/// </summary>
    public class TreatmentRepository
    {
        private HotelSPADataContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="RestApp.Repository.TreatmentRepository"/> class.
		/// </summary>
        public TreatmentRepository()
        {
            context = new HotelSPADataContext();
        }

		/// <summary>
		/// Gets all treatments.
		/// </summary>
		/// <returns>All treatments.</returns>
        public IEnumerable<TreatmentViewModel> GetAll()
        {
            List<TreatmentViewModel> Treatments = new List<TreatmentViewModel>();

            var treatments = context.Treatments.Select(t => t).ToList();
            foreach (var data in treatments)
            {
                Treatments.Add(new TreatmentViewModel()
                {
                    Id = data.Id,
                    Description = data.Description,
                    Duration = data.Duration,
                    Name = data.Name,
                    Price = data.Price//,
                    //Active = data.Active==1 ? true : false
                });
            }
            return Treatments;
        }

		/// <summary>
		/// Get the treatment with specified id.
		/// </summary>
		/// <param name="id">Treatment identifier.</param>
        public TreatmentViewModel Get(Guid id)
        {
            return context.Treatments.Where(x => x.Id == id)
                .Select(x => new TreatmentViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Duration = x.Duration,
                    //Active = x.Active == 1 ? true : false,
                    Name = x.Name,
                    Price = x.Price
                }).SingleOrDefault();
        }

		/// <summary>
		/// Add the specified model.
		/// </summary>
		/// <param name="model">Model.</param>
        public void Add(TreatmentViewModel model)
        {
            Treatments treatment = new Treatments()
            {
                Description = model.Description,
                Duration = model.Duration,
                Active = 1,
                Name = model.Name,
                Price = model.Price
            };

            context.Treatments.InsertOnSubmit(treatment);
            context.SubmitChanges();
        }


        /*
        // nie wiem czy potrzebne
        public void Update(Guid id, TreatmentViewModel model)
        {
            var treatment = context.Treatments.Single(x => x.Id == id);
            treatment.Description = model.Description;
            treatment.Duration = model.Duration;
            treatment.Active = 1;
            treatment.Name = model.Name;
            treatment.Price = model.Price;
            context.SubmitChanges();
        }
        public Treatments ChangeStatus(Guid id, bool active)
        {
            var treatment = context.Treatments.Single(x => x.Id == id);
            treatment.Active = active ? 1 : 0;
            context.SubmitChanges();
            return treatment;
        }
        */
    }
}