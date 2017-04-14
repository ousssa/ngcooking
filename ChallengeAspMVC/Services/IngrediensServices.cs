using ChallengeAspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeAspMVC.ViewsModels;
using AutoMapper;

namespace ChallengeAspMVC.Services
{
    public class IngrediensServices : IIngrediensServices
    {
        ApplicationDbContext _db;
        public IngrediensServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<IngredientModels> ListIngrediens()
        {
            List<IngredientViewModels> IngrediensView;
            List<IngredientModels> IngrediensDB = _db.Ingredients.ToList();
            //IngrediensView =  Mapper.Map<List<IngredientModels>, List<IngredientViewModels>>(IngrediensDB);
            return IngrediensDB;
        }

    }
}