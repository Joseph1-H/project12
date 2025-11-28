using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class CommentsList : List<CommentsRec> 
    { 
        public CommentsList() 
        { 
 
        } 
 
        public CommentsList(IEnumerable<CommentsRec> list) :  
base(list) 
        { 
 
        } 
 
        public CommentsList(IEnumerable<BaseEntity> list) :  
base(list.Cast<CommentsRec>().ToList()) 
        { 
 
        } 
    }
}
