using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LikesRec : BaseEntity
    {
        public DateTime Date { get; set; }
        public int PostID { get; set; }
    }
}
