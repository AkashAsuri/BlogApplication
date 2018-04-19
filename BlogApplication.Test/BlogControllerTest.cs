using BlogApplication.Controllers;
using BlogApplication.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlogApplication.Models;
using BlogApplication.DALl;

namespace BlogApplication.Test
{
    [TestClass]
    public class BlogControllerTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public void CheckDisplayBlogsView()
        {
            //Arrange
            var mockBlogRepo = new Mock<IBlogRepository>();

            BlogController blogctrl = new BlogController(mockBlogRepo.Object);
            //Act
            var result = blogctrl.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckAddBlogView()
        {
            //Arrange
            var mockBlogRepo = new Mock<IBlogRepository>();

            BlogController blogctrl = new BlogController(mockBlogRepo.Object);
            //Act
            var result = blogctrl.AddBlog() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddBlog()
        {
            //Arrange
           var blogVM = new BlogVM() { Title = "Blog1", Description = "about webapi", CreatedDate = DateTime.Now };
            var mockBlogRepo = new Mock<IBlogRepository>();

            //mockBlogRepo.Setup(b => b.AddBlog(It.IsAny<BlogApplication.DAL.Blog>)()).Returns(1);

              BlogController blogctrl = new BlogController(mockBlogRepo.Object);

            //ACt
            var result= blogctrl.AddBlog(blogVM);
            //Assert

            Assert.AreEqual(result, 1);


        }
        

    }
}
