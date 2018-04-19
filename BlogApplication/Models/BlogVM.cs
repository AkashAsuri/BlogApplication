using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class BlogVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ShortDescription
        {
            get
            {

                    
                if (Description.Length > 400)
                {
                    return Description.Substring(0, 400);
                }
                else
                {
                    return Description;
                }
            }
        }

        public List<CommentVM> BlogComments { get; set; }
    }
}