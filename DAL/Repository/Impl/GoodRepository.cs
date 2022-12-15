using DAL.EF;
using DAL.Entity;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementation
{
    public class GoodRepository : BaseRepository<Good>, IGoodRepository
    {
        internal GoodRepository(GoodContext context) : base(context)
        {
        }
    }
}
