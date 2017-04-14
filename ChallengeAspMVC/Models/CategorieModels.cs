﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChallengeAspMVC.Models
{
    public class CategorieModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string categorieId { get; set; }
        public string nameToDisplay { get; set; }

    }
}