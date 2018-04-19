using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DAL
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogApplicationContext _dbContext;
        public BlogRepository()
        {
            _dbContext = new BlogApplicationContext();
        }
        public int AddBlog(Blog blogDetails)
        {
            _dbContext.Blog.Add(blogDetails);
            return _dbContext.SaveChanges();

        }

        public int AddComment(Comment commentDetails)
        {
            _dbContext.Comment.Add(commentDetails);
            return _dbContext.SaveChanges();
        }

        public List<Blog> GetAllBlogs()
        {
            return _dbContext.Blog.OrderByDescending(o => o.CreatedDate).ThenByDescending(d => d.Id).ToList();
        }

        public Blog GetBlogDetails(int blogId)
        {
            var blogDetail = _dbContext.Blog.FirstOrDefault(b => b.Id == blogId);
            var commentList = _dbContext.Comment.Where(c => c.BlogId == blogId).ToList();
            blogDetail.BlogComments = commentList;
            return blogDetail;


        }
    }
}
