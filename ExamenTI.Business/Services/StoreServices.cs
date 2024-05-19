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
    public class StoreServices : IStoreServices
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreServices(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public StoreDto AddStore(CreateStoreDto StoreDto)
        {
            var Store = _mapper.Map<Store>(StoreDto);
            return _mapper.Map<StoreDto>(_storeRepository.AddStore(Store));
        }

        public bool DeleteStore(StoreDto StoreDto)
        {
            var store = _storeRepository.GetStoreById(StoreDto.Id);
            if (store == null)
            {
                return false;
            }
            return _storeRepository.DeleteStore(store);
        }

        public bool ExistStoreById(int StoreId)
        {
            return _storeRepository.ExistStoreById(StoreId);
        }

        public bool ExistStoreByBranch(string Branch)
        {
            return _storeRepository.ExistStoreByBranch(Branch);
        }

        public ICollection<StoreDto> GetAllStores()
        {
            var Stores = _storeRepository.GetAllStores();
            return _mapper.Map<ICollection<StoreDto>>(Stores);
        }

        public StoreDto? GetStoreById(int StoreId)
        {
            var Store = _storeRepository.GetStoreById(StoreId);
            return _mapper.Map<StoreDto>(Store);
        }

        public StoreDto UpdateStore(StoreDto StoreDto)
        {
            var Store = _mapper.Map<Store>(StoreDto);
            return _mapper.Map<StoreDto>(_storeRepository.UpdateStore(Store));
        }
    }
}
