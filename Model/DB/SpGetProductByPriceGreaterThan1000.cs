using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCT.SwaggerAPI.Model.DB
{
    public class SpGetProductByPriceGreaterThan1000
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
