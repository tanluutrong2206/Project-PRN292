using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class ProductCategoryConnection
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Categories Category { get; set; }
        public Products Product { get; set; }
    }
}
