using ChallengeAspMVC.Models;
using ChallengeAspMVC.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Services
{
    public interface IRecettesServices
    {
        void AddRecette(RecettesModels recette);
        List<RecettesModels> ListRecette();
        RecettesModels GetRecette(string id);
    }
}