using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using ChallengeAspMVC.Models;
using ChallengeAspMVC.ViewsModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChallengeAspMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<UserManager<ApplicationUser>>();
            //builder.RegisterType<RecettesServices>().As<IRecettesServices>();
            //builder.RegisterType<CommentsServices>().As<ICommentsServices>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


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
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
