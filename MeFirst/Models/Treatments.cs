using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFirst.Models
{
    public class Treatments
    {
        [Required]
        public int TreatmentsId { get; set; }

        public string Moisturizer { get; set; }

        public string Retinal { get; set; }

        public string Toner { get; set; }

        public string Spf { get; set; }

        [Required]
        public string SkinTypeId { get; set; }

        // user can have multiple treatments for one skin problem 1 to many relationship
        public Browse Browse { get; set; }

        public List<SkinType> SkinType{ get; set; }
     
    }
}
