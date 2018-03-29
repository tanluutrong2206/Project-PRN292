using System;
using System.Collections.Generic;

namespace Project_PRN292_MVC.Models
{
    public partial class Categories
    {
        public Categories()
        {
            ProductCategoryConnection = new HashSet<ProductCategoryConnection>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string ImageName {
            get { return ImageName; }
            set
            {
                ImageName = $"images/{value}";
            }
        }

        public ICollection<ProductCategoryConnection> ProductCategoryConnection { get; set; }
    }
}
