using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Loader:User
    {
        public int FabletId { get; set; }

        public Loader(int id, string name, string userName, string password, int fabletId) : base(id, name, userName, password)
        {
            if (fabletId > 0)
                FabletId = fabletId;
        }
    }
}
