using ExamenTI.Business.DTOs;

namespace ExamenTI.Business.Interfaces;

public interface IClientServices
{
    ICollection<ClientDto> GetAllClients();
    ClientDto? GetClientById(int ClientId);
    bool ExistClientByName(string Firstname, string Surname);
    bool ExistClientById(int ClientId);
    ClientDto AddClient(CreateClientDto clientDto);
    ClientDto UpdateClient(ClientDto clientDto);
    bool DeleteClient(ClientDto clientDto);
}
