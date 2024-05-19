using ExamenTI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Repository.IRepository
{
    public interface IStoreRepository
    {
        ICollection<Store> GetAllStores();
        Store? GetStoreById(int StoreId);
        bool ExistStoreByBranch(string Branch);
        bool ExistStoreById(int StoreId);
        Store AddStore(Store Store);
        Store UpdateStore(Store Store);
        bool DeleteStore(Store Store);
        bool Save();
    }
}
