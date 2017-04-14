using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.ViewsModels
{
    public class CategorieViewModels
    {
        public string categorieId { get; set; }
        public string nameToDisplay { get; set; }

    }
}