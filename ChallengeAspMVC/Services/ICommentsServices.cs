using ChallengeAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Services
{
    public interface ICommentsServices
    {
        void addCommentToRecette(CommentsModels commet); 
    }
}