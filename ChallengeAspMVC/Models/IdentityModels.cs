using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAspMVC.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe ApplicationUser ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
        public int level { get; set; }
        public string picture { get; set; }
        public string city { get; set; }
        public int birth { get; set; }
        public string bio { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<RecettesModels> Recettes { get; set; }
        public DbSet<CategorieModels> Categories { get; set; }
        public DbSet<IngredientModels> Ingredients { get; set; }
        public DbSet<CommentsModels> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public void Seed(ApplicationDbContext Context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Context));
            string name = "Admin";
            string password = "123456";


            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
            }

            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = name;
            var adminresult = UserManager.Create(user, password);
            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }


            var communaute = new List<ApplicationUser>
            {
                new ApplicationUser{
                firstname= "Oussama",
                UserName= "om@c17e.com",
                surname= "MAAZI",
                Email= "om@c17e.com",
                level= 3,
                picture= "img/users/hetta-van-deventer.jpg",
                city= "Brive la Gaillarde",
                birth= 1972,
                bio= "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Alfredo",
                UserName= "alfredo@mail.com",
                surname= "Linguini",
                Email= "alfredo@mail.com",
                level= 1,
                picture= "img/users/alfredo-linguini.jpg",
                city= "Dunkerque",
                birth= 1993,
                bio= "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Jean",
                UserName= "jean@mail.com",
                surname= "Bonneau",
                Email= "jean@mail.com",
                level= 2,
                picture= "img/users/jean-bonneau.jpg",
                city= "Marseille",
                birth= 1982,
                bio= "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Rose",
                UserName= "rose@mail.com",
                surname= "Bihff",
                Email= "rose@mail.com",
                level= 2,
                picture= "img/users/rose-bihff.jpg",
                city= "Melun",
                birth= 1957,
                bio= "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Pierre",
                UserName= "pierrem@mail.com",
                surname= "Musarro",
                Email= "pierrem@mail.com",
                level= 2,
                picture= "img/users/pierrem.jpg",
                city= "Napoli",
                birth= 1981,
                bio= "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Murasso Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Jonathan",
                UserName= "jonathan@mail.com",
                surname= "Baher",
                Email= "jonathan@mail.com",
                level= 2,
                picture= "img/users/jonathan.jpg",
                city= "Tunis",
                birth= 1980,
                bio= "Lorem ipsum behar dolor sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Nicolas",
                UserName= "nicolas@mail.com",
                surname= "Bouscal",
                Email= "nicolas@mail.com",
                level= 2,
                picture= "img/users/nicolas.jpg",
                city= "Dublin",
                birth= 1981,
                bio= "Lorem ipsum behar dolor bascoul sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            },
            new ApplicationUser{
                firstname= "Alexandre",
                UserName= "alexandre@mail.com",
                surname= "Seed",
                Email= "alexandre@mail.com",
                level= 3,
                picture= "img/users/alexandre.jpg",
                city= "Compiègne",
                birth= 1989,
                bio= "Lorem ipsum behar dolor dees sit amet, consectetur adipisicing elit. Odio aspernatur fuga quisquam iusto, eum veniam vel cumque autem assumenda nulla illum accusamus, expedita animi quaerat temporibus saepe magnam, dolor minima."
            }
            };

            foreach (var UserCom in communaute)
            {
                var adminresult1 = UserManager.Create(UserCom, "123456");
                //Add User Admin to Role Admin
                if (adminresult1.Succeeded)
                {
                    var result = UserManager.AddToRole(UserCom.Id, name);
                }
            }



            Context.SaveChanges();
            var test = Context.Comments.ToList();
            var categories = new List<Models.CategorieModels>
            {
                new Models.CategorieModels{
                    categorieId= "meat",
                    nameToDisplay= "Viandes"
                },
                new Models.CategorieModels{
                    categorieId= "fish",
                    nameToDisplay= "Poissons"
                },
                new Models.CategorieModels{
                    categorieId= "seafood",
                    nameToDisplay= "Fruits de mer"
                },
                new Models.CategorieModels{
                    categorieId= "fruit",
                    nameToDisplay= "Fruits"
                },
                new Models.CategorieModels{
                    categorieId= "vegetable",
                    nameToDisplay= "Légumes"
                },
                new Models.CategorieModels{
                    categorieId= "drink",
                    nameToDisplay= "Boissons"
                },
                new Models.CategorieModels{
                    categorieId= "alcohol",
                    nameToDisplay= "Alcools"
                },
                new Models.CategorieModels{
                    categorieId= "cereal",
                    nameToDisplay= "Céréales"
                },
                new Models.CategorieModels{
                    categorieId= "dairy-product",
                    nameToDisplay= "Produits laitiers"
                },
                new Models.CategorieModels{
                    categorieId= "cheese",
                    nameToDisplay= "Fromages"
                },
                new Models.CategorieModels{
                    categorieId= "other",
                    nameToDisplay= "Autre"
                }
            };
            categories.ForEach(s => Context.Categories.Add(s));
            Context.SaveChanges();

            var ingredients = new List<Models.IngredientModels>
            {
                new Models.IngredientModels{
                    IngredientId= "pomme-de-terre",
                    name= "Pomme de terre",
                    isAvailable= true,
                    picture= "pomme-de-terre.jpg",
                    categorieId= "vegetable",
                    calories= 140,
                    description="Test Description"
                },
                new Models.IngredientModels{
                    IngredientId= "boeuf",
                    name= "Boeuf",
                    isAvailable= true,
                    picture= "boeuf.jpg",
                    categorieId= "meat",
                    calories= 200
                },
                new Models.IngredientModels{
                    IngredientId= "poulet",
                    name= "Poulet",
                    isAvailable= true,
                    picture= "poulet.jpg",
                    categorieId= "meat",
                    calories= 180
                },
                new Models.IngredientModels{
                    IngredientId= "citron",
                    name= "Citron",
                    isAvailable= true,
                    picture= "citron.jpg",
                    categorieId= "fruit",
                    calories= 110
                },
                new Models.IngredientModels{
                    IngredientId= "sucre",
                    name= "Sucre",
                    isAvailable= true,
                    picture= "sucre.jpg",
                    categorieId= "other",
                    calories= 600
                },
                new Models.IngredientModels{
                    IngredientId= "farine",
                    name= "Farine",
                    isAvailable= true,
                    picture= "farine.jpg",
                    categorieId= "other",
                    calories= 310
                },
                new Models.IngredientModels{
                    IngredientId= "tomate",
                    name= "Tomate",
                    isAvailable= true,
                    picture= "tomate.jpg",
                    categorieId= "fruit",
                    calories= 80
                },
                new Models.IngredientModels{
                    IngredientId= "carotte",
                    name= "Carotte",
                    isAvailable= true,
                    picture= "carotte.jpg",
                    categorieId= "vegetable",
                    calories= 65
                },
                new Models.IngredientModels{
                    IngredientId= "ananas",
                    name= "Ananas",
                    isAvailable= true,
                    picture= "ananas.jpg",
                    categorieId= "fruit",
                    calories= 95
                },
                new Models.IngredientModels{
                    IngredientId= "aubergine",
                    name= "Aubergine",
                    isAvailable= true,
                    picture= "aubergine.jpg",
                    categorieId= "vegetable",
                    calories= 50
                },
                new Models.IngredientModels{
                    IngredientId= "banane",
                    name= "Banane",
                    isAvailable= true,
                    picture= "banane.jpg",
                    categorieId= "fruit",
                    calories= 210
                },
                new Models.IngredientModels{
                    IngredientId= "biere",
                    name= "Bière",
                    isAvailable= true,
                    picture= "biere.jpg",
                    categorieId= "alcohol",
                    calories= 140
                },
                new Models.IngredientModels{
                    IngredientId= "brocolis",
                    name= "Brocolis",
                    isAvailable= true,
                    picture= "brocolis.jpg",
                    categorieId= "vegetable",
                    calories= 80
                },
                new Models.IngredientModels{
                    IngredientId= "citron-vert",
                    name= "Citron vert",
                    isAvailable= true,
                    picture= "citron-vert.jpg",
                    categorieId= "fruit",
                    calories= 80
                },
                new Models.IngredientModels{
                    IngredientId= "colin",
                    name= "Colin",
                    isAvailable= true,
                    picture= "colin.jpg",
                    categorieId= "fish",
                    calories= 80
                },
                new Models.IngredientModels{
                    IngredientId= "creme",
                    name= "Crème",
                    isAvailable= true,
                    picture= "creme.jpg",
                    categorieId= "dairy-product",
                    calories= 80
                },
                new Models.IngredientModels{
                    IngredientId= "crevettes",
                    name= "Crevettes",
                    isAvailable= true,
                    picture= "crevettes.jpg",
                    categorieId= "seafood",
                    calories= 100
                },
                new Models.IngredientModels{
                    IngredientId= "echalotte",
                    name= "Echalotte",
                    isAvailable= true,
                    picture= "echalotte.jpg",
                    categorieId= "vegetable",
                    calories= 30
                },
                new Models.IngredientModels{
                    IngredientId= "fraise",
                    name= "Fraise",
                    isAvailable= true,
                    picture= "fraise.jpg",
                    categorieId= "fruit",
                    calories= 130
                },
                new Models.IngredientModels{
                    IngredientId= "glace",
                    name= "Glace",
                    isAvailable= true,
                    picture= "glace.jpg",
                    categorieId= "other",
                    calories= 0
                },
                new Models.IngredientModels{
                    IngredientId= "gruyere",
                    name= "Gruyère",
                    isAvailable= true,
                    picture= "gruyere.jpg",
                    categorieId= "cheese",
                    calories= 430
                },
                new Models.IngredientModels{
                    IngredientId= "huile-olive",
                    name= "Huile d'olive",
                    isAvailable= true,
                    picture= "huile-olive.jpg",
                    categorieId= "other",
                    calories= 850
                },
                new Models.IngredientModels{
                    IngredientId= "Huile",
                    name= "huile-tournesol",
                    isAvailable= true,
                    picture= "huile-tournesol.jpg",
                    categorieId= "other",
                    calories= 900
                },
                new Models.IngredientModels{
                    IngredientId= "jambon",
                    name= "Jambon",
                    isAvailable= true,
                    picture= "jambon.jpg",
                    categorieId= "meat",
                    calories= 270
                },
                new Models.IngredientModels{
                    IngredientId= "kiwi",
                    name= "Kiwi",
                    isAvailable= true,
                    picture= "kiwi.jpg",
                    categorieId= "fruit",
                    calories= 145
                },
                new Models.IngredientModels{
                    IngredientId= "lait",
                    name= "Lait",
                    isAvailable= true,
                    picture= "lait.jpg",
                    categorieId= "dairy-product",
                    calories= 500
                },
                new Models.IngredientModels{
                    IngredientId= "mais",
                    name= "Maïs",
                    isAvailable= true,
                    picture= "mais.jpg",
                    categorieId= "cereal",
                    calories= 160
                },
                new Models.IngredientModels{
                    IngredientId= "noix-de-coco",
                    name= "Noix de coco",
                    isAvailable= true,
                    picture= "noix-de-coco.jpg",
                    categorieId= "fruit",
                    calories= 100
                },
                new Models.IngredientModels{
                    IngredientId= "oeuf",
                    name= "Oeuf",
                    isAvailable= true,
                    picture= "oeuf.jpg",
                    categorieId= "other",
                    calories= 450
                },
                new Models.IngredientModels{
                    IngredientId= "olives",
                    name= "Olives",
                    isAvailable= true,
                    picture= "olives.jpg",
                    categorieId= "fruit",
                    calories= 490
                },
                new Models.IngredientModels{
                    IngredientId= "orange",
                    name= "Orange",
                    isAvailable= true,
                    picture= "orange.jpg",
                    categorieId= "fruit",
                    calories= 105
                },
                new Models.IngredientModels{
                    IngredientId= "pamplemousse",
                    name= "Pamplemousse",
                    isAvailable= true,
                    picture= "pamplemousse.jpg",
                    categorieId= "fruit",
                    calories= 100
                },
                new Models.IngredientModels{
                    IngredientId= "pasteque",
                    name= "Pastèque",
                    isAvailable= true,
                    picture= "pasteque.jpg",
                    categorieId= "fruit",
                    calories= 40
                },
                new Models.IngredientModels{
                    IngredientId= "poire",
                    name= "Poire",
                    isAvailable= true,
                    picture= "poire.jpg",
                    categorieId= "vegetable",
                    calories= 65
                },
                new Models.IngredientModels{
                    IngredientId= "pomme",
                    name= "Pomme",
                    isAvailable= true,
                    picture= "pomme.jpg",
                    categorieId= "fruit",
                    calories= 55
                },
                new Models.IngredientModels{
                    IngredientId= "raisin",
                    name= "Raisin",
                    isAvailable= true,
                    picture= "raisin.jpg",
                    categorieId= "fruit",
                    calories= 90
                },
                new Models.IngredientModels{
                    IngredientId= "salade",
                    name= "Salade",
                    isAvailable= true,
                    picture= "salade.jpg",
                    categorieId= "vegetable",
                    calories= 25
                },
                new Models.IngredientModels{
                    IngredientId= "saumon",
                    name= "saumon",
                    isAvailable= true,
                    picture= "Saumon.jpg",
                    categorieId= "fish",
                    calories= 250
                },
                new Models.IngredientModels{
                    IngredientId= "thon",
                    name= "Thon",
                    isAvailable= true,
                    picture= "thon.jpg",
                    categorieId= "fish",
                    calories= 180
                },
                new Models.IngredientModels{
                    IngredientId= "toast",
                    name= "Toast",
                    isAvailable= true,
                    picture= "toast.jpg",
                    categorieId= "other",
                    calories= 160
                },
                new Models.IngredientModels{
                    IngredientId= "vin-rouge",
                    name= "Vin Rouge",
                    isAvailable= true,
                    picture= "vin-rouge.jpg",
                    categorieId= "alcohol",
                    calories= 70
                }

            };

            var ingredients1 = new List<Models.IngredientModels>
            {
                new Models.IngredientModels{
                    IngredientId= "pomme-de-terre",
                    name= "Pomme de terre",
                    isAvailable= true,
                    picture= "pomme-de-terre.jpg",
                    categorieId= "vegetable",
                    calories= 140
                }
            };
            ingredients.ForEach(s => Context.Ingredients.Add(s));
            Context.SaveChanges();

            var Ing = Context.Ingredients.First();
            var recettes = new List<Models.RecettesModels>
            {
            new Models.RecettesModels{
                    ID="tarte-citron-meringue",
                    name="Tarte citron meringué",
                    isAvailable=true,
                    picture="img/recettes/tarte-citron-meringue.jpg",
                    calories=460,
                    USerAsp=user,
                    preparation="<p>PÂTE:</p><p>Blanchir les jaunes et le sucre au fouet et détendre le mélange avec un peu d'eau.</p><p>Mélanger au doigt la farine et le beurre coupé en petites parcelles pour obtenir une consistance sableuse et que tout le beurre soit absorbé (!!! Il faut faire vite pour que le mélange ne ramollisse pas trop!).</p><p>Verser au milieu de ce 'sable' le mélange liquide.</p><p>Incoporer au couteau les éléments rapidement sans leur donner de corps.</p><p>Former une boule avec les paumes et fraiser 1 ou 2 fois pour rendre la boule + homogène.</p><p>Foncez un moule de 25 cm de diamètre avec la pâte, garnissez la de papier sulfurisé et de haricots secs.</p><p>Faites cuire à blanc 20 à 25 mn, à 180°C, Th 6-7 . (NB après baisser le four à 120°C/150°C environ pour la meringue).</p><p>CRÈME AU CITRON :</p><p>Laver les citrons et en 'zester' 2.</p><p>Mettre les zestes très fins dans une casserole.</p><p>Presser les citrons et mettre le jus avec les zestes dans la casserole.</p><p>Verser le sucre et la Maïzena.</p><p>Remuer, et commencer à faire chauffer à feux doux.</p><p>Battre les oeufs dans un récipients séparé.</p><p>Une fois les oeufs battus, incorporer tout en remuant le jus de citron, le sucre, la Maïzena et les zestes.</p><p>Mettre à feu fort et continuer à remuer à l'aide d'un fouet.</p><p>Le mélange va commencer à s'épaissir.</p><p>Attention de toujours remuer lorsque les oeufs sont ajoutés, car la crème de citron pourrait brûler.</p><p>Oter du feux et verser l'appareil sur le fond de tarte cuit.</p><p>MERINGUE :</p><p>Monter les blancs en neige avec une pincée de sel.</p><p>Quand ils commencent à être fermes, ajouter le sucre puis la levure.</p><p>Mixer jusqu'à ce que la neige soit ferme.</p><p>Recouvrir avec les blancs en neige et napper. Cuire à four doux (120°C/150°C) juqu'à ce que la meringue dore (10 mn)",
                }
            };

            recettes.First().ingredientsObj = Context.Ingredients.Where(i => i.IngredientId == "oeuf"
                                                                        || i.IngredientId == "citron"
                                                                        || i.IngredientId == "sucre"
                                                                        || i.IngredientId == "farine").ToList();

            var comments = new List<Models.CommentsModels>
            {
                new Models.CommentsModels{userId=1,comment="Test Comment",mark=2,title="titre Comment",Recette = recettes.First() }
            };

            Context.Comments.Add(comments.First());

            recettes.ForEach(s => Context.Recettes.Add(s));
            Context.SaveChanges();

        }
    }
}