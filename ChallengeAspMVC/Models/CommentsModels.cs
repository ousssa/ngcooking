using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ChallengeAspMVC.Models
{
    [JsonObject]
    public class CommentsModels
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public string userAspId { get; set; }
        [ForeignKey("userAspId")]
        public virtual ApplicationUser USerAsp { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public int mark { get; set; }

        public string RecetteId { get; set; }

        [JsonIgnore]
        //[ScriptIgnore]
        [ForeignKey("RecetteId")]
        public virtual RecettesModels Recette { get; set; }
    }
}