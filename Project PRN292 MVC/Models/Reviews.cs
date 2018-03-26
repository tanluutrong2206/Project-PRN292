using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }

        public Customers Customer { get; set; }
        public Products Product { get; set; }
    }
}
