using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public override void Save(Category item)
        {
            if(item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, cat => cat.ID == item.ID);
            }
        }
    }
}
