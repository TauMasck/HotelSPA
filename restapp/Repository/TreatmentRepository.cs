using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApp.Repository
{
    public class TreatmentRepository
    {
        private HotelSPADataContext context;

        public TreatmentRepository()
        {
            context = new HotelSPADataContext();
        }

        public IEnumerable<TreatmentViewModel> GetTreatments()
        {
            List<TreatmentViewModel> Treatments = new List<TreatmentViewModel>();

            var treatments = context.Treatments.Select(t => t).ToList();
            foreach (var data in treatments)
            {
                Treatments.Add(new TreatmentViewModel()
                {
                    Id = data.Id,
                    Decription = data.Description,
                    Duration = data.Duration,
                    Name = data.Name,
                    Price = data.Price,
                    Active = data.Active==1 ? true : false
                });
            }
            return Treatments;
        }

        public void SaveTreatment(TreatmentViewModel model)
        {
            Treatments treatment = new Treatments()
            {
                Description = model.Decription,
                Duration = model.Duration,
                Active = model.Active ? 1 : 0,
                Name = model.Name,
                Price = model.Price
            };

            context.Treatments.InsertOnSubmit(treatment);
            context.SubmitChanges();
        }


        // nie wiem czy potrzebne
        public void UpdateTreatmentById(int id, TreatmentViewModel model)
        {
            var treatment = context.Treatments.Single(x => x.Id == id);
            treatment.Description = model.Decription;
            treatment.Duration = model.Duration;
            treatment.Active = model.Active ? 1 : 0;
            treatment.Name = model.Name;
            treatment.Price = model.Price;
            context.SubmitChanges();
        }

        public void ChangeTreatmentStatusById(int id, bool active)
        {
            var treatment = context.Treatments.Single(x => x.Id == id);
            treatment.Active = active ? 1 : 0;
            context.SubmitChanges();
        }
    }
}