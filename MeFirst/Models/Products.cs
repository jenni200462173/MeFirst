using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFirst.Models
{
    public class Products
    {
        public int ProductsId { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string SkinType { get; set; }

        public string Combination { get; set; }

        public string SkinTypeID { get; set; }
        // Adding a parent refrence to browse 
       
        public List <SkinType> SkinTypes{ get; set; }
    }
}
