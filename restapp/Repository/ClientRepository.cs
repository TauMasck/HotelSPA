using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApp.Models;

namespace RestApp.Repository
{
	/// <summary>
	/// Client repository class.
	/// </summary>
    public class ClientRepository
    {
		/// <summary>
		/// The context.
		/// </summary>
        private HotelSPADataContext _context;
        private TreatmentRepository _treatmentRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="RestApp.Repository.ClientRepository"/> class.
		/// </summary>
        public ClientRepository()
        {
            _context = new HotelSPADataContext();
            _treatmentRepository = new TreatmentRepository();
        }

		/// <summary>
		/// Gets all clients.
		/// </summary>
		/// <returns>All clients.</returns>
        public IEnumerable<ClientViewModel> GetAll()
        {
            List<ClientViewModel> clientsList = new List<ClientViewModel>();

            var query = from client in _context.Clients
                        select client;
            var clients = query.ToList();
            foreach (var data in clients)
            {
                clientsList.Add(new ClientViewModel()
                {
                    Id = data.Id,
                    NameSurname = data.Name_surname,
                    IdNumber = data.Id_number,
                    Company = data.Company == null ? "" : data.Company,
                    RoomNumber = data.Room_number,
                    IsHere = data.Is_here == 0 ? false : true,
                    Vegetarian = data.Vegetarian == 0 ? false : true,
                    Questionnaire = data.Questionnaire == 0 ? false : true,
                    Invoice = data.Invoice == 0 ? false : true
                });
            }
            return clientsList;
        }
			
		/// <summary>
		/// Get the client with specified id.
		/// </summary>
		/// <param name="id">Identifier.</param>
        public ClientViewModel Get(Guid id)
        {
            return _context.Clients.Where(x => x.Id == id)
                .Select(x => new ClientViewModel()
                {
                    Id = x.Id,
                    NameSurname = x.Name_surname,
                    IdNumber = x.Id_number,
                    Company = x.Company == null ? "" : x.Company,
                    RoomNumber = x.Room_number,
                    IsHere = x.Is_here == 0 ? false : true,
                    Vegetarian = x.Vegetarian == 0 ? false : true,
                    Questionnaire = x.Questionnaire == 0 ? false : true,
                    Invoice = x.Invoice == 0 ? false : true
                }).SingleOrDefault();
        }

		/// <summary>
		/// Get the treatments history of a client with specified id.
		/// </summary>
		/// <returns>The treatments history.</returns>
		/// <param name="id">Identifier.</param>
        public IEnumerable<ClientHistoryViewModel> GetTreatmentsHistory(Guid id)
        {
            return _context.TreatmentsHistories.Where(x => x.Client_id == id)
                .Select(x => new ClientHistoryViewModel()
                {
                    ClientId = x.Client_id,
                    Treatment = _treatmentRepository.Get(x.Treatment_id),
                    ThisStay = x.This_stay == 0 ? false : true,
                    IsDone = x.Is_done == 0 ? false : true
                });
        }


		/// <summary>
		/// Add the specified client.
		/// </summary>
		/// <param name="model">Model.</param>
        public void Add(ClientViewModel model)
        {
            Clients client = new Clients()
            {
                Name_surname = model.NameSurname,
                Id_number = model.IdNumber,
                Company = model.Company == "" ? null : model.Company,
                Room_number = model.RoomNumber,
                Is_here = model.IsHere ? 0 : 1,
                Vegetarian = model.Vegetarian ? 0 : 1,
                Questionnaire = model.Questionnaire ? 0 : 1,
                Invoice = model.Invoice ? 0 : 1,
            };

            _context.Clients.InsertOnSubmit(client);
            _context.SubmitChanges();
        }


		/// <summary>
		/// Update the client with specified model.
		/// </summary>
		/// <param name="model">Model.</param>
        public Clients Update(ClientViewModel model)
        {            
            var client = _context.Clients.Single(x => x.Id == model.Id);
            client.Name_surname = model.NameSurname;
            client.Id_number = model.IdNumber;
            client.Company = model.Company == "" ? null : model.Company;
            client.Room_number = model.RoomNumber;
            client.Is_here = model.IsHere ? 0 : 1;
            client.Vegetarian = model.Vegetarian ? 0 : 1;
            client.Questionnaire = model.Questionnaire ? 0 : 1;
            client.Invoice = model.Invoice ? 0 : 1;
            _context.SubmitChanges();

            return client;
        }

		/// <summary>
		/// Delete the client with specified id.
		/// </summary>
		/// <param name="id">Identifier.</param>
        public Clients Delete(Guid id)
        {
            var client = _context.Clients.Single(x => x.Id == id);
            _context.Clients.DeleteOnSubmit(client);
            _context.SubmitChanges();
            return client;
        }

    }
}