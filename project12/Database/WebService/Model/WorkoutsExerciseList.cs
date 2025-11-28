using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WorkoutsExerciseList : List<WorkoutsRec>
    {
        public WorkoutsExerciseList()
        {

        }

        public WorkoutsExerciseList(IEnumerable<WorkoutsRec> list) :
base(list)
        {

        }

        public WorkoutsExerciseList(IEnumerable<BaseEntity> list) :
base(list.Cast<WorkoutsRec>().ToList())
        {

        }
    }
}
