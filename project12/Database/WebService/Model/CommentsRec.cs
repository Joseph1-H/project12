using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommentsRec : BaseEntity
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int CommentsID { get; set; }
        public string CountryName { get; set; }
    }
}
