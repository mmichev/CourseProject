using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    class UserRepository : BaseRepository<User>
    {
        public override void Save(User item)
        {
            if(item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, user => user.ID == item.ID);
            }
        }
    }
}
