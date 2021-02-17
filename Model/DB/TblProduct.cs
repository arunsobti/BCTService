using System;
using System.Collections.Generic;

namespace BCT.SwaggerAPI.Model.DB
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
