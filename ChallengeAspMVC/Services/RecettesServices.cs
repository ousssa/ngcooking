using AutoMapper;
using ChallengeAspMVC.Models;
using ChallengeAspMVC.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Services
{
    public class RecettesServices: IRecettesServices
    {
        ApplicationDbContext _db;
        IIngrediensServices _ingrediensServices;
        public RecettesServices(ApplicationDbContext db, IIngrediensServices ingrediensServices)
        {
            _db = db;
            _ingrediensServices = ingrediensServices;
        }
        public void AddRecette (RecettesModels recette)
        {
            //var RecettesView = Mapper.Map<RecettesViewModels,RecettesModels >(recette);
            RecettesModels RecettesModel = new RecettesModels {
                ID = recette.ID
                //ingredientsObj = Mapper.Map<List<IngredientViewModels>, List<IngredientModels>>(recette.ingredientsObj.ToList())
            };

            //RecettesModels RecettesModell = new RecettesModels();
            //var Ingredients = _ingrediensServices.ListIngrediens().Where(x => RecettesModel.ingredientsObj.Select(y=>y.IngredientId).Contains(x.IngredientId)).ToList();
            //RecettesModell.ingredientsObj = Ingredients;
            //RecettesModel = Mapper.Map<RecettesViewModels, RecettesModels>(recette);
            
            _db.Recettes.Add(recette);
            _db.SaveChanges();
        }

        public List<RecettesModels> ListRecette()
        {
            var RecettesDB = _db.Recettes.ToList();
            Mapper.Configuration.AssertConfigurationIsValid();
            var RecettesView = Mapper.Map<List<RecettesModels>, List<RecettesViewModels>>(RecettesDB);
            return RecettesDB;
            
        }
        public RecettesModels GetRecette(string id)
        {
            var RecetteDB = _db.Recettes.Where(x=>x.ID==id).FirstOrDefault();
            return RecetteDB;

        }

    }
}