using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.ViewsModels
{
    public class RecettesViewModels
    {
   
        public string ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string name { get; set; }
        public string userAspId { get; set; }
        public bool isAvailable { get; set; }
        public string picture { get; set; }
        public int calories { get; set; }
        public List<string> category = new List<string>();
        public int IngredientId { get; set; }
        public virtual ICollection<IngredientViewModels> ingredientsObj { get; set; }

        [StringLength(500, MinimumLength = 20)]
        public string preparation { get; set; }
        public virtual ICollection<CommentsViewModels> comments { get; set; }
    }

    public class category
    {

        private IDictionary<int,string> CategoryList;
        public category()
        {
            CategoryList.Add(1, "plate");
            CategoryList.Add(1, "Desert");
            CategoryList.Add(1, "Creme");
        }
    }
}