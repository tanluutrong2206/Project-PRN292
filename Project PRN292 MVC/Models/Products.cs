using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class Products
    {
        public Products()
        {
            ProductCategoryConnection = new HashSet<ProductCategoryConnection>();
            Reviews = new HashSet<Reviews>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Sale { get; set; }
        public int UnitInStock { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public string ImageName
        {
            get { return ImageName; }
            set
            {
                ImageName = $"images/{value}";
            }
        }


        public ICollection<ProductCategoryConnection> ProductCategoryConnection { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
