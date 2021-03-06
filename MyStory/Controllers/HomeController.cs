﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyStory.Models;
using MyStory.Models.Infrastructure;
using MarkdownDeep;
using AutoMapper;
using MyStory.ViewModels;
using MyStory.QueryObjects;

namespace MyStory.Controllers
{
    public class HomeController : MyStoryController
    {
        public ActionResult Index(int page=1)
        {
            ViewBag.NumberOfAccounts = DbContext.Accounts.Count();

            int perPage = page == 1 ? 20 : 10;

            var posts = new PostQuery() { CurrentPageNumber=page, PostsPerPage=perPage}.GetQuery(DbContext).ToList();

            var postListViewModel = Mapper.Map<List<Post>, List<PostListViewModel>>(posts);

            return View("Index", postListViewModel);
        }

       

    }
}
