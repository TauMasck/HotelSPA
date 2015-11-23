using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApp.Models;

namespace RestApp.Repository
{
    public class ClientRepository
    {
        private HotelSPADataContext context;

        public ClientRepository()
        {
            context = new HotelSPADataContext();
        }

        public IEnumerable<Client> GetClients()
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

        public Client GetClientById(int id)
        {
            return context.Clients.Where(x => x.Id == id)
                .Select(x => new Client()
                {
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
        }

        public void SaveClient(Client model)
        {
            Clients client = new Clients()
            {
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
        }

        public void UpdateClientById(int id, Client model)
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

        public Clients DeleteClientById(int id)
        {
            var client = context.Clients.Single(x => x.Id == id);
            context.Clients.DeleteOnSubmit(client);
            context.SubmitChanges();
            return client;
        }

    }
}