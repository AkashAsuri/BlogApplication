using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class CommentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="please enter comment")]
        public string CommentText { get; set; }

        public DateTime CommentedDate { get; set; }
        public int BlogId { get; set; }
    }
}