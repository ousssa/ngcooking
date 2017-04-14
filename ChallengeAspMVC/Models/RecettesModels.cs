using ChallengeAspMVC.ViewsModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Models
{
    public class RecettesModels
    {
   
        [Key]
        public string ID { get; set; }
        public string name { get; set; }
        // public virtual CommunauteModels user { get; set; }     
        public string userAspId { get; set; }
        [ForeignKey("userAspId")]
        public virtual ApplicationUser USerAsp { get; set; }
        public bool isAvailable { get; set; }
        public string picture { get; set; }
        public int calories { get; set; }
        [NotMapped]
        public List<string> category = new List<string> { "plat", "entre", "dessert" };
        public int IngredientId { get; set; }
        public virtual ICollection<IngredientModels> ingredientsObj { get; set; }
        public string preparation { get; set; }
        public virtual ICollection<CommentsModels> comments { get; set; }
    }
}