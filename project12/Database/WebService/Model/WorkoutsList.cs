using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WorkoutsList : List<WorkoutsRec>
    {
        public WorkoutsList()
        {

        }

        public WorkoutsList(IEnumerable<WorkoutsRec> list) :
base(list)
        {

        }

        public WorkoutsList(IEnumerable<BaseEntity> list) :
base(list.Cast<WorkoutsRec>().ToList())
        {

        }
    }
}
