using DAL.EF;
using DAL.Entity;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementation
{
    public class GoodTypeRepository : BaseRepository<GoodType>, IGoodTypeRepository
    {
        public GoodTypeRepository(GoodContext context) : base(context)
        {
        }
    }
}
