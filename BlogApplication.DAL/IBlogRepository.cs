using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DAL
{
    public interface IBlogRepository
    {
        List<Blog> GetAllBlogs();
        Blog GetBlogDetails(int blogId);
        int AddBlog(Blog blogDetails);

        int AddComment(Comment commentDetails);


    }
}
