using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PostsList : List<PostsRec>
    {
        public PostsList()
        {

        }

        public PostsList(IEnumerable<PostsRec> list) :
base(list)
        {

        }

        public PostsList(IEnumerable<BaseEntity> list) :
base(list.Cast<PostsRec>().ToList())
        {

        }
    }
}
