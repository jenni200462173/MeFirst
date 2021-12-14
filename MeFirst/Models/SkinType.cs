using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MeFirst.Models
{
  [Authorize(Roles = "Administrator")]
    public class SkinType
    {
        [Required]
        [Key]
        public int SkyinTypeId { get; set; }

        public string Dry { get; set; }

        public string Aging { get; set; }

        public string Oily { get; set; }

        public string Combination { get; set; }

        public string TreatmentsID { get; set; }
        // Adding a parent refrence to browse 
        public Browse Browse { get; set; }

        public List <Treatments> Treatments { get; set; }
    }
}
