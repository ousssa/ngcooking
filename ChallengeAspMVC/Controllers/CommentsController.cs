using AutoMapper;
using ChallengeAspMVC.Models;
using ChallengeAspMVC.Services;
using ChallengeAspMVC.ViewsModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChallengeAspMVC.Controllers
{
    public class CommentsController : Controller
    {
        ICommentsServices _commentsServices;
        IRecettesServices _recettesServicess;

        public CommentsController(ICommentsServices commentsServices, IRecettesServices recettesServicess)
        {
            _commentsServices = commentsServices;
            _recettesServicess = recettesServicess;
        }
        // GET: Comments
        public ActionResult Index()
        {
           return View();
        }

        // GET: Comments/Details/5
        public ActionResult Details(string id)
        {
            
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userAspId,RecetteID,comment,title,mark")] CommentsViewModels CommentViewModels)
        {

            var comment = Mapper.Map<CommentsViewModels, CommentsModels>(CommentViewModels);
            _commentsServices.addCommentToRecette(comment);
            //return RedirectToAction("Recettes", "Details", "");
            return Redirect(Request.UrlReferrer.PathAndQuery);


        }

    }
}
