using AutoMapper;
using BlogApplication.DAL;
using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Blog, BlogVM>().ReverseMap();
                cfg.CreateMap<Comment, CommentVM>().ReverseMap();
            });
        }
    }
}