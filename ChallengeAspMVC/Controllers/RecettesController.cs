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
    public class RecettesController : Controller
    {
        IIngrediensServices _ingrediensServices;
        IRecettesServices _recettesServicess;

        public RecettesController(IIngrediensServices ingrediensServices, IRecettesServices recettesServicess)
        {
            _ingrediensServices = ingrediensServices;
            _recettesServicess = recettesServicess;
        }
        // GET: Recettes
        public ActionResult Index()
        {
            var Ingredients= _ingrediensServices.ListIngrediens();
            var Recettes = _recettesServicess.ListRecette();
            var RecettesView = Mapper.Map<List<RecettesModels>, List<RecettesViewModels>>(Recettes);
            return View(RecettesView);
        }

        // GET: Recettes/Details/5
        public ActionResult Details(string id)
        {

            var Recette = _recettesServicess.GetRecette(id);
            var RecetteView = Mapper.Map<RecettesModels, RecettesViewModels>(Recette);
            RecetteView.ID = id;
            RecetteView.name = id.Replace("-"," ");
            return View(RecetteView);
        }

        // GET: Recettes/Create
        public ActionResult Create()
        {
            RecettesViewModels rvm= new RecettesViewModels();
            rvm.ingredientsObj = Mapper.Map<List<IngredientModels>, List<IngredientViewModels>>(_ingrediensServices.ListIngrediens());
            return View(rvm);
        }

        // POST: Recettes/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,creatorId,isAvailable,calories,preparation")] RecettesViewModels recettesViewModels, string[] ingredientsObj, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                RecettesViewModels rvm = new RecettesViewModels();
                rvm.ingredientsObj = Mapper.Map<List<IngredientModels>, List<IngredientViewModels>>(_ingrediensServices.ListIngrediens());
                return View(rvm);
            }
            // TODO: Add insert logic here
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/img/recettes"), fileName);
                file.SaveAs(path);
                recettesViewModels.picture = "img/recettes/" + fileName;
            }
            else
            {
                recettesViewModels.picture = "img/recettes/tarte-citron-meringue.jpg";
            }

            //check if ingredien betin 4 and 10
            if (ingredientsObj == null || ingredientsObj.Length > 10 || ingredientsObj.Length < 4)
            {
                return Json("{'KO'}");
            }

            //Add User to the Recette 

            recettesViewModels.userAspId = User.Identity.GetUserId();

            var recettesModels = new RecettesModels();
            recettesModels = Mapper.Map<RecettesViewModels, RecettesModels>(recettesViewModels);
            var Ingredientsdb = _ingrediensServices.ListIngrediens();
            var ss = (from u in Ingredientsdb
                      where ingredientsObj.Contains(u.IngredientId)
                       select u);
            var Ingredients = _ingrediensServices.ListIngrediens().Where(a => ingredientsObj.Any(x => x == a.IngredientId)).ToList();
            //Add Ingredient to Recette
            recettesModels.ingredientsObj = Ingredients;
            //generate Recette ID from the Recette Name
            var id = recettesViewModels.name.ToLower().Replace(" ","-");
            recettesModels.ID = id;
                
            var ssss = recettesViewModels.name;

            _recettesServicess.AddRecette(recettesModels);
            return RedirectToAction("Index");
              

        }

        // GET: Recettes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recettes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recettes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recettes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
