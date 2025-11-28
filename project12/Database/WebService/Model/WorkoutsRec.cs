using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WorkoutsRec : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Visibility { get; set; }
        public int WorkoutsID { get; set; }
    }
}
