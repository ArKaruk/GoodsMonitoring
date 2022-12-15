using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private GoodContext db;
        private GoodRepository goodRepository;
        private StorageRepository storageRepository;
        private GoodTypeRepository typeRepository;

        public EFUnitOfWork(GoodContext context)
        {
            db = context;
        }
        public IGoodRepository Goods
        {
            get
            {
                if (goodRepository == null)
                    goodRepository = new GoodRepository(db);
                return goodRepository;
            }
        }

        public IStorageRepository Storages
        {
            get
            {
                if (storageRepository == null)
                    storageRepository = new StorageRepository(db);
                return storageRepository;
            }
        }

        public IGoodTypeRepository Types
        {
            get 
            { 
                if(typeRepository == null)
                    typeRepository= new GoodTypeRepository(db);
                return typeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
