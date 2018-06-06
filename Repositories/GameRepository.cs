using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    class GameRepository : BaseRepository<Game>
    {
        public override void Save(Game item)
        {
            if(item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, game => game.ID == item.ID);
            }
        }
    }
}
