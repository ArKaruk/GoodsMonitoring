using DAL.EF;
using DAL.Entity;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementation
{
    public class StorageRepository : BaseRepository<Storage>, IStorageRepository
    {
        internal StorageRepository(GoodContext context) : base(context)
        {
        }
    }
}
