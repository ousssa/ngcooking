using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeAspMVC.Services;
using Moq;
using ChallengeAspMVC.Models;
using System.Linq;
using System.Collections.Generic;
using ChallengeAspMVC.Controllers;
using System.Web.Mvc;
using AutoMapper;
using ChallengeAspMVC.ViewsModels;

namespace ChallengeAspMVCTest
{
    [TestClass]
    public class RecettesControllerTest
    {
        public RecettesControllerTest()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<IngredientModels, IngredientViewModels>()
                .ForSourceMember(src => src.Recettes, opt => opt.Ignore())
                .ForMember(src => src.category, opt => opt.MapFrom(s => s.category))
                .ForMember(src => src.Recettes, opt => opt.Ignore());
                cfg.CreateMap<IngredientViewModels, IngredientModels>().MaxDepth(1)
                .ForSourceMember(src => src.Recettes, opt => opt.Ignore())
                .ForMember(src => src.category, opt => opt.MapFrom(s => s.category))
                .ForMember(src => src.Recettes, opt => opt.Ignore());


                cfg.CreateMap<CategorieModels, CategorieViewModels>().ReverseMap();
                cfg.CreateMap<RecettesModels, RecettesViewModels>().ReverseMap().MaxDepth(1)
                .ForMember(src => src.ingredientsObj, opt => opt.Ignore());

                cfg.CreateMap<CommentsModels, CommentsViewModels>().MaxDepth(1)
                .ForMember(src => src.Recette, opt => opt.Ignore())
                .ForSourceMember(src => src.Recette, opt => opt.Ignore())
                .ForSourceMember(src => src.USerAsp, opt => opt.Ignore());

                cfg.CreateMap<CommentsViewModels, CommentsModels>().MaxDepth(1)
                .ForMember(src => src.Recette, opt => opt.Ignore())
                .ForSourceMember(src => src.Recette, opt => opt.Ignore())
                .ForMember(src => src.USerAsp, opt => opt.Ignore());
            });
        }

        [TestMethod]
        public void TestDetailsAction()
        {
            var mock = new Mock<IRecettesServices>();
            mock.Setup(x => x.GetRecette("1"));
            var foo = mock.Object;
            // Initial value was stored
            Mock<IRecettesServices> mockIRecette = new Mock<IRecettesServices>();
            Mock<IIngrediensServices> mockIIntgredient = new Mock<IIngrediensServices>();

            mockIRecette.Setup(r => r.GetRecette("1")).Returns(new RecettesModels() {ID="1",preparation="test preparation" });
            var v = mockIRecette.Object.GetRecette("1");

            mockIIntgredient.Setup(i => i.ListIngrediens()).Returns(GetIngredient());

            var controller = new RecettesController(mockIIntgredient.Object, mockIRecette.Object);
            var result = controller.Details("1");
            ViewResult vResult = result as ViewResult;
            RecettesViewModels model = vResult.Model as RecettesViewModels; 
            Assert.AreEqual("1", model.ID);
        }
        private List<IngredientModels> GetIngredient()
        {
            List<IngredientModels> users = new List<IngredientModels>();
            users.Add(new IngredientModels() { IngredientId="pomme"});
            users.Add(new IngredientModels() { IngredientId = "temp"});
            return users;
        }
        [TestMethod]
        public void TestGenerateIdFromTitle()
        {
           
        }
        
    }
}
