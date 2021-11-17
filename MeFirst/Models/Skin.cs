using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFirst.Models
{
    public class skinType
    {
        //in .net,for pk fields,use the name {Model}Id or just id
        public int SkintypeId { get; set; }
        public string Remedy { get; set; }
    }
}
