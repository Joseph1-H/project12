using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class AdminsList : List<AdminsRec>
    {
        public AdminsList()
        {

        }

        public AdminsList(IEnumerable<AdminsRec> list) :
base(list)
        {

        }

        public AdminsList(IEnumerable<BaseEntity> list) :
base(list.Cast<AdminsRec>().ToList())
        {

        }
    }
}
