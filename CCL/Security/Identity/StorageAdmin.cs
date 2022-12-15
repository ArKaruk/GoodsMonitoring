using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class StorageAdmin:User
    {
        public int LapTopId { get; set; }
        public int StorageId { get; set; }

        public StorageAdmin(int id, string name, string userName, string password, int lapTopId, int storageId) : base(id, name, userName, password)
        {
            if (lapTopId > 0)
                LapTopId = lapTopId;

            if (storageId > 0)
                StorageId = storageId;
        }
    }
}
