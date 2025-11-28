using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExercisesList : List<ExercisesRec>
    {
        public ExercisesList()
        {

        }

        public ExercisesList(IEnumerable<ExercisesRec> list) :
base(list)
        {

        }

        public ExercisesList(IEnumerable<BaseEntity> list) :
base(list.Cast<ExercisesRec>().ToList())
        {

        }
    }
}
