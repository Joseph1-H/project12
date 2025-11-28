using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LikesList : List<LikesRec>
    {
        public LikesList()
        {

        }

        public LikesList(IEnumerable<LikesRec> list) :
base(list)
        {

        }

        public LikesList(IEnumerable<BaseEntity> list) :
base(list.Cast<LikesRec>().ToList())
        {

        }
    }
}
