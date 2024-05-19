using ExamenTI.DataAccess.Entities;
using ExamenTI.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _db;
        public ClientRepository(AppDbContext db)
        {
            _db = db;
        }
        public Client AddClient(Client client)
        {
            _db.tblClient.Add(client);
            _db.SaveChanges();
            return client;
        }

        public bool DeleteClient(Client client)
        {
            if (_db.Entry(client).State == EntityState.Detached) { 
                _db.tblClient.Attach(client);
            }

            _db.tblClient.Remove(client);
            return Save();
        }

        public bool ExistClientById(int ClientId)
        {
            return _db.tblClient.Any(x => x.Id == ClientId);
        }

        public bool ExistClientByName(string Firstname, string Surname)
        {
            return _db.tblClient.Any(x => x.Firstname.ToLower().Trim() == Firstname.ToLower().Trim() &&
            x.Surname.ToLower().Trim() == Surname.ToLower().Trim());
        }

        public ICollection<Client> GetAllClients()
        {
            return _db.tblClient.OrderBy(x => x.Firstname).ToList();
        }

        public Client? GetClientById(int ClientId)
        {
            return _db.tblClient.FirstOrDefault(x => x.Id == ClientId);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public Client UpdateClient(Client client)
        {
            _db.tblClient.Update(client);
            _db.SaveChanges();
            return client;
        }
    }
}
