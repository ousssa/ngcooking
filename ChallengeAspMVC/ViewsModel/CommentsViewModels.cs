using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ChallengeAspMVC.ViewsModels
{
    public class CommentsViewModels
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string userAspId { get; set; }
        public string title { get; set; }

        [StringLength(300, MinimumLength = 5)]
        public string comment { get; set; }
        public int mark { get; set; }

        public string RecetteId { get; set; }

        public virtual RecettesViewModels Recette { get; set; }
    }
}