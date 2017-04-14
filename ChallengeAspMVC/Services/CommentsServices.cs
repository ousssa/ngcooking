using ChallengeAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Services
{
    public class CommentsServices : ICommentsServices
    {
        ApplicationDbContext _db;
        public CommentsServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public void addCommentToRecette(CommentsModels comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
        }
    }
}