using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Good
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int StorageId { get; set; }

        public int Amount { get; set; }
        public int TypeId { get; set; }
    }
}
