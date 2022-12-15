using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class GoodContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<GoodType> Types { get; set; }

        public GoodContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
