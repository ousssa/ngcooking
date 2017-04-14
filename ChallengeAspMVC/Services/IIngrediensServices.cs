using ChallengeAspMVC.Models;
using ChallengeAspMVC.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Services
{
    public interface IIngrediensServices
    {
        List<IngredientModels> ListIngrediens();
    }
}