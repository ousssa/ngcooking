using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Models
{
    public class CommunauteModels
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int level { get; set; }
        public string picture { get; set; }
        public string city { get; set; }
        public int birth { get; set; }
        public string bio { get; set; }
    }
}