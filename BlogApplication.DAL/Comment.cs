using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DAL
{
   public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }

        public DateTime CommentedDate { get; set; }
        public int BlogId { get; set; }
    }
}
