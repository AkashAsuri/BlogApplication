using BlogApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepo)
        {
            _blogRepository = blogRepo;
        }
        /// <summary>
        /// </summary>
        /// <returns>List of blogs from database</returns>
        public ActionResult Index()
        {
            var blogData = Mapper.Map<List<Blog>, List<BlogVM>>(_blogRepository.GetAllBlogs());
            return View("Index", blogData);
        }
        /// <summary>
        /// Returns blog view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBlog()
        {
            return View("AddBlog");
        }

        /// <summary>
        /// Create blog record.
        /// </summary>
        /// <param name="blog">blogview model object</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBlog([Bind(Exclude = "Id")]BlogVM blog)
        {
            //validation of model 
            if (ModelState.IsValid)
            {
                var newblogdata = Mapper.Map<BlogVM, Blog>(blog);
                newblogdata.CreatedDate = DateTime.Now;
                _blogRepository.AddBlog(newblogdata);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Detail(int blogId)
        {
            var blog = Mapper.Map<Blog, BlogVM>(_blogRepository.GetBlogDetails(blogId));
            return View(blog);
        }
        [ChildActionOnly]
        public ActionResult PostComment(int blogId)
        {
            return PartialView(new CommentVM { BlogId = blogId });
        }

        [HttpPost]
        public ActionResult PostComment([Bind(Exclude = "Id")]CommentVM comment)
        {
            if (ModelState.IsValid)
            {
                var newcommentdata = Mapper.Map<CommentVM, Comment>(comment);
                newcommentdata.CommentedDate = DateTime.Now;
                _blogRepository.AddComment(newcommentdata);
                return RedirectToAction("Detail", new { blogId = comment.BlogId });
            }
            return View();
        }
    }
}