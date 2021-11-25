﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFirst.Models
{
    public class SkinType
    {
        [Required]
        [Key]
        public int SkyinTypeId { get; set; }

        public string Dry { get; set; }

        public string Aging { get; set; }

        public string Oily { get; set; }

        public string Combination { get; set; }

        [Required]
        public string TreatmentsID { get; set; }
        // Adding a parent refrence to browse 
        public Browse Browse { get; set; }

        public List <Treatments> Treatments { get; set; }
    }
}
