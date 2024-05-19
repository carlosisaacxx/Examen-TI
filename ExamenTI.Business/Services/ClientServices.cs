using AutoMapper;
using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using ExamenTI.DataAccess.Entities;
using ExamenTI.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientServices(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public ClientDto AddClient(CreateClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            return _mapper.Map<ClientDto>(_clientRepository.AddClient(client));
        }

        public bool DeleteClient(ClientDto clientDto)
        {
            var client = _clientRepository.GetClientById(clientDto.Id);
            if (client == null) {
                return false;
            }
            return _clientRepository.DeleteClient(client);
        }

        public bool ExistClientById(int ClientId)
        {
            return _clientRepository.ExistClientById(ClientId);
        }

        public bool ExistClientByName(string Firstname, string Surname)
        {
            return _clientRepository.ExistClientByName(Firstname, Surname);
        }

        public ICollection<ClientDto> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            return _mapper.Map<ICollection<ClientDto>>(clients);
        }

        public ClientDto? GetClientById(int ClientId)
        {
            var client = _clientRepository.GetClientById(ClientId);
            return _mapper.Map<ClientDto>(client);
        }

        public ClientDto UpdateClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            return _mapper.Map<ClientDto>(_clientRepository.UpdateClient(client));
        }
    }
}
