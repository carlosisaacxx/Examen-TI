using ExamenTI.Business.DTOs;

namespace ExamenTI.Business.Interfaces;

public interface IStoreServices
{
    ICollection<StoreDto> GetAllStores();
    StoreDto? GetStoreById(int StoreId);
    bool ExistStoreByBranch(string Branch);
    bool ExistStoreById(int StoreId);
    StoreDto AddStore(CreateStoreDto StoreDto);
    StoreDto UpdateStore(StoreDto StoreDto);
    bool DeleteStore(StoreDto StoreDto);
}
