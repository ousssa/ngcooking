using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Models
{
    [Table("IngredientModels")]
    public class IngredientModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IngredientId { get; set; }
        public string name { get; set; }
        public bool isAvailable { get; set; }
        public string picture { get; set; }
        public string categorieId { get; set; }
        public virtual CategorieModels category { get; set; }
        public virtual ICollection<RecettesModels> Recettes { get; set; }
        public int calories { get; set; }
        public string description { get; set; }

    }
}