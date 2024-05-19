using ExamenTI.DataAccess.Entities;
using ExamenTI.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ExamenTI.DataAccess.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _db;

        public StoreRepository(AppDbContext db)
        {
            _db = db;
        }
        public Store AddStore(Store store)
        {
            _db.tblStore.Add(store);
            _db.SaveChanges();
            return store;
        }

        public bool DeleteStore(Store Store)
        {
            if (_db.Entry(Store).State == EntityState.Detached)
            {
                _db.tblStore.Attach(Store);
            }
            _db.tblStore.Remove(Store);
            return Save();
        }

        public bool ExistStoreByBranch(string Branch)
        {
            return _db.tblStore.Any(x => x.Branch.ToLower().Trim() == Branch.ToLower().Trim());
        }

        public bool ExistStoreById(int StoreId)
        {
            return _db.tblStore.Any(x => x.Id == StoreId);
        }

        public ICollection<Store> GetAllStores()
        {
            return _db.tblStore.OrderBy(x => x.Branch).ToList();
        }

        public Store? GetStoreById(int StoreId)
        {
            return _db.tblStore.FirstOrDefault(x => x.Id == StoreId);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public Store UpdateStore(Store Store)
        {
            _db.tblStore.Update(Store);
            _db.SaveChanges();
            return Store;
        }
    }
}
