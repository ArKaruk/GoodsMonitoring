using AutoMapper;
using BLL.DTO;
using DAL.Entity;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GoodService
    {
        private readonly IUnitOfWork _database;
        private int amountOnPage = 20;

        public GoodService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<GoodDTO> GetEmergencies(int emergencyTypeId, int page)
        {
            var goodsEntities = _database.Goods.Find(g => g.TypeId == emergencyTypeId, page, amountOnPage);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Good, GoodDTO>()).CreateMapper();
            var goods = mapper.Map<IEnumerable<Good>, List<GoodDTO>>(goodsEntities);

            return goods;
        }
    }
}
