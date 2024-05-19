using ExamenTI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Repository.IRepository
{
    public interface IClientRepository
    {
        ICollection<Client> GetAllClients();
        Client? GetClientById(int ClientId);
        bool ExistClientByName(string Firstname, string Surname);
        bool ExistClientById(int ClientId);
        Client AddClient(Client client);
        Client UpdateClient(Client client);
        bool DeleteClient(Client client);
        bool Save();
    }
}
