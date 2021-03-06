using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFirst.Models
{
    public class Browse
    {

            [Key]
            public string BrosweId { get; set; }

            [Required(ErrorMessage = "Hey you're missing something")]
            public string User { get; set; }

            //ref to child model; browsing all skinTypes to choose the users skintype 1 to many relationship
            public List<Browse> Skintypes { get; set; }
            public List<Treatments> Treatments { get; set; }
        public string Photo { get; internal set; }
    }
}
